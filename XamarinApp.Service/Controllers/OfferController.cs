using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Xml;
using XamarinApp.Service.Models;

namespace XamarinApp.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OfferController : Controller
    {
        [HttpGet(Name = "GetOffer")]
        public async Task<IEnumerable<Offer>> Get()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            HttpClient httpClient = new HttpClient();
            var answer = await httpClient.GetAsync("http://partner.market.yandex.ru/pages/help/YML.xml");
            var response = await answer.Content.ReadAsByteArrayAsync();
            XmlDocument xDoc = new XmlDocument();
            var responseStr = Encoding.GetEncoding(1251).GetString(response);
            xDoc.LoadXml(responseStr);
            var xNodeOffer = xDoc.DocumentElement.SelectSingleNode("shop").SelectSingleNode("offers");

            var list = new List<Offer>();
            foreach (XmlNode node in xNodeOffer)
            {
                string jsonText = JsonConvert.SerializeXmlNode(node);

                list.Add(new Offer { Id = Convert.ToInt32(node.Attributes.GetNamedItem("id").Value), JsonConent = jsonText });
            }

            return list;
        }
    }
}
