﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Client
{
    public class Helper
    {

    }
    /// <summary>
    /// HTTP method to use when making requests
    /// </summary>
    public enum Method
    {
        Get, Post, Put, Delete, Head, Options,

    }

    public static class TreeViewExtensions
    {
        public static List<TreeNode> Ancestors(this TreeNode node)
        {
            return AncestorsInternal(node).Reverse().ToList();
        }
        public static List<TreeNode> AncestorsAndSelf(this TreeNode node)
        {
            return AncestorsInternal(node, true).Reverse().ToList();
        }
        private static IEnumerable<TreeNode> AncestorsInternal(TreeNode node, bool self = false)
        {
            if (self)
                yield return node;
            while (node?.Parent != null)
            {
                node = node.Parent;
                yield return node;
            }
        }
    }
}
