using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLogger
{
    public interface IMouse
    {
        void Sound();
        void Sound1();
        int MouseCount(decimal legs);

        object MousePet(string name, string color, int colorCount); 
    }
}
