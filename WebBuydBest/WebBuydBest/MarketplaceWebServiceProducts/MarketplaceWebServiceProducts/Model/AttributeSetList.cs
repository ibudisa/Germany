/******************************************************************************* 
 *  Copyright 2008-2012 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"); 
 *  
 *  You may not use this file except in compliance with the License. 
 *  You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 *  specific language governing permissions and limitations under the License.
 * ***************************************************************************** 
 * 
 *  Marketplace Web Service Products CSharp Library
 *  API Version: 2011-10-01
 * 
 */


using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;


namespace MarketplaceWebServiceProducts.Model
{
    [XmlTypeAttribute(Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01")]
    [XmlRootAttribute(Namespace = "http://mws.amazonservices.com/schema/Products/2011-10-01", IsNullable = false)]
    public class AttributeSetList
    {
    

        private  List<Object> anyField;

        /// <summary>
        /// Gets and sets the Any property.
        /// </summary>
        [XmlAnyElementAttribute]
        public List<Object> Any

        {
            get
            {
                if (this.anyField == null)
                {
                    this.anyField = new List<Object>();
                }
                return this.anyField;
            }
            set { this.anyField =  value; }
        }



        /// <summary>
        /// Sets the Any property
        /// </summary>
        /// <param name="list">Any property</param>
        /// <returns>this instance</returns>
        public AttributeSetList WithAny(params Object[] list)
        {
            foreach (Object item in list)
            {
                Any.Add(item);
            }
            return this;
        }          
 


        /// <summary>
        /// Checks if Any property is set
        /// </summary>
        /// <returns>true if Any property is set</returns>
        public Boolean IsSetAny()
        {
            return (Any.Count > 0);
        }


        /// <summary>
        /// XML fragment representation of this object
        /// </summary>
        /// <returns>XML fragment for this object.</returns>
        /// <remarks>
        /// Name for outer tag expected to be set by calling method. 
        /// This fragment returns inner properties representation only
        /// </remarks>


        protected internal String ToXMLFragment() {
            StringBuilder xml = new StringBuilder();
            foreach (var obj in Any)
            {
                System.Xml.XmlElement xmlElement = (System.Xml.XmlElement) obj;
                xml.Append(ProductsUtil.FormatXml(xmlElement));
            }
            return xml.ToString();
        }

        /**
         * 
         * Escape XML special characters
         */
        private String EscapeXML(String str) {
            if (str == null)
                return "null";
            StringBuilder sb = new StringBuilder();
            foreach (Char c in str)
            {
                switch (c) {
                case '&':
                    sb.Append("&amp;");
                    break;
                case '<':
                    sb.Append("&lt;");
                    break;
                case '>':
                    sb.Append("&gt;");
                    break;
                case '\'':
                    sb.Append("&#039;");
                    break;
                case '"':
                    sb.Append("&quot;");
                    break;
                default:
                    sb.Append(c);
                    break;
                }
            }
            return sb.ToString();
        }



    }

}