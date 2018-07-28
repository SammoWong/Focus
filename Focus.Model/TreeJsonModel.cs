using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Model
{
    public class TreeJsonModel
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public string Icon { get; set; }

        public State State { get; set; }

        public List<TreeJsonModel> Children = new List<TreeJsonModel>();
        
        public string ParentId { get; set; }
    }

    public class State
    {
        public bool Opened { get; set; }

        public bool Disabled { get; set; }

        public bool Selected { get; set; }
    }
}
