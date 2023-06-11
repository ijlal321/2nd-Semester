using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanNavigation.BL
{
	class Angle
    {
		int degree;
		float minutes;
		char direction;
		public Angle(int degree, float minutes, char direction) 
        {
			this.degree = degree;
			this.minutes = minutes;
			this.direction = direction;
        }

		public string giveAngle()
        {
			string ans = "";
			ans += degree + "\u00b0" + minutes + "\'" + direction ;
			return ans;
        }
    }
}
