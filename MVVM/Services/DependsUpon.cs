using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Services {
    [global::System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    sealed class DependsUponAttribute : Attribute {
        #region Private Members
        private readonly string[] _properties;
        #endregion

        #region Public Properties
        public string[] Properties {
            get { return _properties; }
        }
        #endregion

        #region Constructors
        public DependsUponAttribute(params string[] properties) {
            this._properties = properties;
        }
        #endregion
    }
}
