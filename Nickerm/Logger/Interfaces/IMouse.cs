using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLogger
{
    public interface IMouse
    {
        void Sound();
        void Move();
        int MouseCount(decimal legs);

        object MousePet(string name, string color, int colorCount); 
    }
}
