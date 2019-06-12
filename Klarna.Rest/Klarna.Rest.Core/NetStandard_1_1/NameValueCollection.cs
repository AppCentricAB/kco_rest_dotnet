using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Klarna.Rest.Core.NetStandard_1_1
{
    //
    // Summary:
    //     Represents a collection of associated System.String keys and System.String values
    //     that can be accessed either with the key or with the index.
    public class NameValueCollection : List<NameValue>
    {
        public NameValueCollection()
        { }

        //
        // Summary:
        //     Gets the entry at the specified index of the System.Collections.Specialized.NameValueCollection.
        //
        // Parameters:
        //   index:
        //     The zero-based index of the entry to locate in the collection.
        //
        // Returns:
        //     A System.String that contains the comma-separated list of values at the specified
        //     index of the collection.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     index is outside the valid range of indexes for the collection.
        public new string this[int index]
        {
            get
            {
                return base[index].Value;
            }
        }
        //
        // Summary:
        //     Gets or sets the entry with the specified key in the System.Collections.Specialized.NameValueCollection.
        //
        // Parameters:
        //   name:
        //     The System.String key of the entry to locate. The key can be null.
        //
        // Returns:
        //     A System.String that contains the comma-separated list of values associated with
        //     the specified key, if found; otherwise, null.
        //
        // Exceptions:
        //   T:System.NotSupportedException:
        //     The collection is read-only and the operation attempts to modify the collection.
        public string this[string name]
        {
            get
            {
                NameValue o = this.Find(i => i.Name == name);

                if (o == null)
                    return null;

                return o.Value;
            }
            set
            {
                NameValue o = this.Find(i => i.Name == name);

                if (o == null)
                    this.Add(name, value);
                else
                    o.Value = value;
            }
        }

        //
        // Summary:
        //     Gets all the keys in the System.Collections.Specialized.NameValueCollection.
        //
        // Returns:
        //     A System.String array that contains all the keys of the System.Collections.Specialized.NameValueCollection.
        public virtual string[] AllKeys
        {
            get
            {
                List<string> result = new List<string>();

                foreach(NameValue o in this)
                {
                    result.Add(o.Name);
                }

                return result.ToArray();
            }
        }

        //
        // Summary:
        //     Copies the entries in the specified System.Collections.Specialized.NameValueCollection
        //     to the current System.Collections.Specialized.NameValueCollection.
        //
        // Parameters:
        //   c:
        //     The System.Collections.Specialized.NameValueCollection to copy to the current
        //     System.Collections.Specialized.NameValueCollection.
        public void Add(NameValueCollection c)
        {
            this.AddRange(c);
        }
        //
        // Summary:
        //     Adds an entry with the specified name and value to the System.Collections.Specialized.NameValueCollection.
        //
        // Parameters:
        //   name:
        //     The System.String key of the entry to add. The key can be null.
        //
        //   value:
        //     The System.String value of the entry to add. The value can be null.
        public virtual void Add(string name, string value)
        {
            this.Add(new NameValue(name, value));
        }
    }

    public class NameValue
    {
        public NameValue()
        { }

        public NameValue(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}
