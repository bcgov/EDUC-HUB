using System.Collections.Generic;

namespace CASInterfaceService.Pages.Models
{
    public class CASAPQueryRegistration
    {
        List<CASAPQuery> casAPQueryList;
        static CASAPQueryRegistration casregd = null;

        // TEST  - molson.cas.gov.bc.ca - 142.34.166.75  - 7015
        // TRAIN - molson.cas.gov.bc.ca - 142.34.166.75  - 7013
        // PROD  - labatt.cas.gov.bc.ca - 142.34.166.201 - 7010

        //private const string URL = "https://<server>:<port>ords/cas/cfs/apinvoice/";
        //private const string URL = "https://molson.cas.gov.bc.ca:7015/ords/cas/cfs/apinvoice/";
        private const string URL = "https://wsgw.test.jag.gov.bc.ca/victim/ords/cas/cfs/apinvoice/";
        //private const string TokenURL = "https://<server>:<port>/ords/casords/oauth/token";
        //private const string TokenURL = "https://molson.cas.gov.bc.ca:7015/ords/casords/oauth/token";
        private const string TokenURL = "https://wsgw.test.jag.gov.bc.ca/victim/ords/cas/oauth/token";

        private CASAPQueryRegistration()
        {
            casAPQueryList = new List<CASAPQuery>();
        }

        public static CASAPQueryRegistration getInstance()
        {
            if (casregd == null)
            {
                casregd = new CASAPQueryRegistration();
                return casregd;
            }
            else
            {
                return casregd;
            }
        }

        public void Add(CASAPQuery casapQuery)
        {
            casAPQueryList.Add(casapQuery);
        }

        public List<CASAPQuery> getAllCASAPQuery()
        {
            return casAPQueryList;
        }

        public List<CASAPQuery> getUpdateCASAPQuery()
        {
            return casAPQueryList;
        }
    }
}
