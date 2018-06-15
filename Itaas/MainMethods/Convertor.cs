using System;
using System.Collections.Generic;
using System.Text;

namespace Itaas.MainMethods
{
    public partial class Convertor
    {
        public string Format(string line)
        {

            string[] agoraFormat = new string[13];
            string CDNFormat = "\"MINHA CDN\"";

            agoraFormat = line.Split('|', '/', '.', '"', ' ');
            Validate(agoraFormat);


            if (agoraFormat[7] != "txt")
            {
                CDNFormat += " " + agoraFormat[4] + " " + agoraFormat[1] +
                    " " + "/" + agoraFormat[6] + " " + agoraFormat[11] + " " +
                    agoraFormat[0] + " " + agoraFormat[2];

            }
            else if (agoraFormat[2] == "INVALIDATE")
            {
                agoraFormat[2] = "REFRESH_HIT";
                CDNFormat += " " + agoraFormat[4] + " " + agoraFormat[1] + " " + "/" +
                    agoraFormat[6] + "." + agoraFormat[7] + " " +
                     "" + agoraFormat[12] + " " + agoraFormat[0] + " " + agoraFormat[2];

            }
            else
            {
                CDNFormat += " " + agoraFormat[4] + " " + agoraFormat[1] + " " + "/" +
                    agoraFormat[6] + "." + agoraFormat[7] + " " +
                    "" + agoraFormat[12] + " " + agoraFormat[0] + " " + agoraFormat[2];

            }


            return CDNFormat;
        }

        public bool Validate(string[] converted)
        {
            int number = 0;

            if (!Int32.TryParse(converted[0], out number) || !Int32.TryParse(converted[1], out number) || !Int32.TryParse(converted[12], out number) ||
                Int32.TryParse(converted[2], out number) || Int32.TryParse(converted[4], out number) || Int32.TryParse(converted[6], out number) ||
                    Int32.TryParse(converted[7], out number)) return false;

            return true;
        }
    }
}
