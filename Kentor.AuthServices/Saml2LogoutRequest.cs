using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Kentor.AuthServices
{
    /// <summary>
    /// A logout request corresponding to section 3.7.1 in SAML Core specification.
    /// </summary>
    public class Saml2LogoutRequest : Saml2RequestBase
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Saml2LogoutRequest()
        {

        }

        /// <summary>
        /// The SAML2 request name
        /// </summary>
        protected override string LocalName
        {
            get { return "LogoutRequest"; }
        }

        /// <summary>
        /// Serializes the request to a Xml message.
        /// </summary>
        /// <returns>XElement</returns>
        public XElement ToXElement()
        {
            var x = new XElement(Saml2Namespaces.Saml2P + LocalName);

            x.Add(base.ToXNodes());

            return x;
        }

        /// <summary>
        /// Serializes the message into wellformed Xml.
        /// </summary>
        /// <returns>string containing the Xml data.</returns>
        public override string ToXml()
        {
            return ToXElement().ToString();
        }

        /// <summary>
        /// Read the supplied Xml and parse it into a logoutrequest.
        /// </summary>
        /// <param name="xml">xml data.</param>
        /// <returns>Saml2Request</returns>
        /// <exception cref="XmlException">On xml errors or unexpected xml structure.</exception>
        public static Saml2LogoutRequest Read(string xml)
        {
            if (xml == null)
            {
                return null;
            }
            var x = new XmlDocument();
            x.PreserveWhitespace = true;
            x.LoadXml(xml);

            return new Saml2LogoutRequest(x);
        }

        private Saml2LogoutRequest(XmlDocument xml)
        {
            ReadBaseProperties(xml);
        }
    }
}