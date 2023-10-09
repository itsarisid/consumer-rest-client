using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connector.Models;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

namespace Connector.Client
{
    public static class Utilities
    {
        private sealed class IndexContainer
        {
            private int _n;
            public int Inc() => _n++;
        }

        /// <summary>Fills the TreeView.</summary>
        /// <param name="node">The node.</param>
        /// <param name="tok">The tok.</param>
        /// <param name="s">The s.</param>
        private static void FillTreeView(TreeNode node, JToken tok, Stack<IndexContainer> s)
        {
            if (tok.Type == JTokenType.Object)
            {
                TreeNode n = node;
                if (tok.Parent != null)
                {
                    if (tok.Parent.Type == JTokenType.Property)
                    {
                        n = node.Nodes.Add($"{((JProperty)tok.Parent).Name} <{tok.Type.ToString()}>");
                    }
                    else
                    {
                        n = node.Nodes.Add($"[{s.Peek().Inc()}] <{tok.Type.ToString()}>");
                    }
                }
                s.Push(new IndexContainer());
                foreach (var p in tok.Children<JProperty>())
                {
                    FillTreeView(n, p.Value, s);
                }
                s.Pop();
            }
            else if (tok.Type == JTokenType.Array)
            {
                TreeNode n = node;
                if (tok.Parent != null)
                {
                    if (tok.Parent.Type == JTokenType.Property)
                    {
                        n = node.Nodes.Add($"{((JProperty)tok.Parent).Name} <{tok.Type.ToString()}>");
                    }
                    else
                    {
                        n = node.Nodes.Add($"[{s.Peek().Inc()}] <{tok.Type.ToString()}>");
                    }
                }
                s.Push(new IndexContainer());
                foreach (var p in tok)
                {
                    FillTreeView(n, p, s);
                }
                s.Pop();
            }
            else
            {
                var name = string.Empty;
                var value = JsonConvert.SerializeObject(((JValue)tok).Value);

                if (tok.Parent.Type == JTokenType.Property)
                {
                    name = $"{((JProperty)tok.Parent).Name} : {value}";
                }
                else
                {
                    name = $"[{s.Peek().Inc()}] : {value}";
                }

                node.Nodes.Add(name);
            }
        }

        /// <summary>Sets the object as json.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tv">The tv.</param>
        /// <param name="obj">The object.</param>
        public static void SetObjectAsJson<T>(this TreeView tv, T obj)
        {
            tv.BeginUpdate();
            try
            {
                tv.Nodes.Clear();

                var s = new Stack<IndexContainer>();
                s.Push(new IndexContainer());
                FillTreeView(tv.Nodes.Add("ROOT"), JsonConvert.DeserializeObject<JToken>(JsonConvert.SerializeObject(obj)), s);
                s.Pop();
            }
            finally
            {
                tv.EndUpdate();
            }
        }

        /// <summary>Converts to header.</summary>
        /// <param name="headers">The headers.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static List<Header> ConvertToHeader(this DataGridViewRowCollection headers) => (from row in headers.OfType<DataGridViewRow>()
                                                                                               where row.Cells["Key"]?.Value != null && row.Cells["Value"]?.Value != null
                                                                                               select new Header
                                                                                               {
                                                                                                   Key = row.Cells["Key"].Value.ToString(),
                                                                                                   Value = row.Cells["Value"].Value.ToString(),
                                                                                                   IsActive = true
                                                                                               }).ToList();

        /// <summary>Converts to query parameters.</summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static List<QueryParameter> ConvertToQueryParameters(this DataGridViewRowCollection parameters) => (from row in parameters.OfType<DataGridViewRow>()
                                                                                                                   where row.Cells["QKey"]?.Value != null && row.Cells["QValue"]?.Value != null
                                                                                                                   select new QueryParameter
                                                                                                                   {
                                                                                                                       Key = row.Cells["QKey"].Value.ToString(),
                                                                                                                       Value = row.Cells["QValue"].Value.ToString(),
                                                                                                                       IsActive = true
                                                                                                                   }).ToList();

        /// <summary>Parse JSON string, individual tokens become TreeView Nodes ~mwr</summary>
        /// <param name="oTV">TreeView control to display parsed JSON</param>
        /// <param name="sJSON">Incoming JSON string</param>
        /// <param name="rootName">Title of top node in TreeView wrapping all JSON</param>
        public static void JsonToTreeview(TreeView oTV, string sJSON, string rootName)
        {
            JContainer json = sJSON.StartsWith("[")
                            ? (JContainer)JArray.Parse(sJSON)
                            : (JContainer)JObject.Parse(sJSON);

            oTV.Nodes.Add(Utilities.Ele2Node(json, rootName));
        }

        /// <summary>Ele2s the node.</summary>
        /// <param name="oJthingy">The o jthingy.</param>
        /// <param name="text">The text.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="System.Exception">clsJSON2Treeview can't interpret object:" + oJthingy.GetType().Name</exception>
        public static TreeNode Ele2Node(object oJthingy, string text = "")
        {
            TreeNode oThisNode = new TreeNode(text);

            switch (oJthingy.GetType().Name) //~mwr could not find parent object for all three JObject, JArray, JValue
            {
                case "JObject":
                    foreach (KeyValuePair<string, JToken> oJtok in (JObject)oJthingy)
                        oThisNode.Nodes.Add(Ele2Node(oJtok.Value, oJtok.Key));
                    break;
                case "JArray":
                    int i = 0;
                    foreach (JToken oJtok in (JArray)oJthingy)
                        oThisNode.Nodes.Add(Ele2Node(oJtok, string.Format("[{0}]", i++)));

                    if (i == 0) oThisNode.Nodes.Add("[]"); //to handle empty arrays
                    break;
                case "JValue":
                    oThisNode.Nodes.Add(new TreeNode(oJthingy.ToString()));
                    break;
                default:
                    throw new System.Exception("clsJSON2Treeview can't interpret object:" + oJthingy.GetType().Name);
            }

            return oThisNode;
        }
    }
}
