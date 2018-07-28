using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Model.Dictionary
{
    public class DictionaryTypeOutputModel
    {
        public string Id { get; set; }

        public string ParentId { get; set; }

        public string Name { get; set; }

        public List<DictionaryTypeOutputModel> Children = new List<DictionaryTypeOutputModel>();
    }
}
