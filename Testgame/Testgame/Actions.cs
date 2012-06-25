﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Testgame
{
    class Actions
    {
        // Linear Movement
        public static float LinearMove(float start, float end, float d, float t)
        {
            return (end - start) * t / d + start;
        }

        // Quad Movement (Ease In/Out)
        public static float QuadMove(float start, float end, float d, float t)
        {
            t /= d/2;
            if ((t) < 1) return (end - start) / 2 * t * t + start;
            return -(end - start) / 2 * ((--t) * (t - 2) - 1) + start;
        }  
        
        //Movement that goes slightly too far (based on s) and then comes back
        public static MoveDel GetBackMove(float s)
        {
            return delegate(float start, float end, float d, float t)
            {
                t = t / d - 1;
                return (end - start) * ((t - 1) * t * ((s + 1) * t + s) + 1) + start;
            };
        }

        // Exponential Easing Out
        public static float ExpoMove(float start, float end, float d, float t)
        {
            return (t == d) ? start + (end - start) : (end - start) * (-(float)Math.Pow(2, -10 * t / d) + 1) + start;
        }

        // Exponential Easing In
        public static float ExpoMoveIn(float start, float end, float d, float t)
        {
            
		return (t==0) ? start : (end - start) * (float)Math.Pow(2, 10 * (t/d - 1)) + start;
	}
    }
}
