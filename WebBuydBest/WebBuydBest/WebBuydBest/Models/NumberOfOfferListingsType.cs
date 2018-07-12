/******************************************************************************* 
 *  Copyright 2008-2009 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
 *  Generated: Tue Jan 10 21:27:52 GMT 2012 
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
    public class NumberOfOfferListingsType
    {
    
        private  String conditionField;
        private  Decimal valueField;


        /// <summary>
        /// Gets and sets  the condition property.
        /// </summary>
        [XmlAttributeAttribute(AttributeName = "condition")]
        public String condition
        {
            get { return this.conditionField ; }
            set { this.conditionField = value; }
        }



        /// <summary>
        /// Sets the condition property
        /// </summary>
        /// <param name="condition">condition property</param>
        /// <returns>this instance</returns>
        public NumberOfOfferListingsType Withcondition(String condition)
        {
            this.conditionField = condition;
            return this;
        }



        /// <summary>
        /// Checks if condition property is set
        /// </summary>
        /// <returns>true if condition property is set</returns>
        public Boolean IsSetcondition()
        {
            return this.conditionField  != null;

        }


        /// <summary>
        /// Gets and sets  the Value property.
        /// </summary>
        [XmlTextAttribute()]
        public Decimal Value
        {
            get { return this.valueField ; }
            set { this.valueField = value; }
        }



        /// <summary>
        /// Sets the Value property
        /// </summary>
        /// <param name="value">Value property</param>
        /// <returns>this instance</returns>
        public NumberOfOfferListingsType WithValue(Decimal value)
        {
            this.valueField = value;
            return this;
        }




        /// <summary>
        /// Checks if Value property is set
        /// </summary>
        /// <returns>true if Value property is set</returns>
        public Boolean IsSetValue()
        {
            return true;

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
            return xml.ToString();
        }

        /**
         * 
         * Escape XML special characters
         */
        private String EscapeXML(String str) {
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