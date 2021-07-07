namespace Algorithms_Practice.BackTracking
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class ReConstructIpAddress
    {
        private IList<string> result;
        public IList<string> RestoreIpAddresses(string s) {
            result = new List<string>();
            RestoreIpAddressesHelper(s, new StringBuilder(), 0);
            return result;
        }
        private void RestoreIpAddressesHelper(string s, StringBuilder validIp, int level)
        {
            if(s.Length == 0 && level == 4)
            {
                result.Add(validIp.ToString());
                return;
            }
            if(s.Length == 0 || level == 4)
            {
                return;
            }
            
            for(int i = 0; i < 3 && i < s.Length; i++)
            {
                string ipSegment = new String(s.Substring(0, i + 1));

                if(IsZeroLeadingIp(ipSegment))
                {
                    return;
                }

                if(!IsIPBound(ipSegment))
                {
                    return;
                }
                string newInput = s.Remove(0, i + 1);
                
                if(validIp.Length != 0)
                    ipSegment = "." + ipSegment;

                validIp.Append(ipSegment);
                    
                RestoreIpAddressesHelper(newInput, validIp, level + 1);

                validIp.Remove(validIp.Length - ipSegment.Length, ipSegment.Length);
            }
        }

        private bool IsZeroLeadingIp(string ipSegment)
        {
            if(ipSegment.StartsWith('0') && ipSegment.Length > 1)
            {
                return true;
            }
            return false;
        }
        private bool IsIPBound(string ipSegment)
        {
            if(int.TryParse(ipSegment, out int intIpSegment))
            {
                if(intIpSegment > 255)
                {
                    return false;
                }
            }
            return true;
        }
    }
}