using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public class Animals
{
    private string _description = "Description";

    public string Description
    {
        get => _description;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                value = "###";
            }

            value = value.Trim();


            value = Validator.Shortener(value, 3, 15, '#');

            if (char.IsLower(value[0]))
            {
                value = char.ToUpper(value[0]) + value.Substring(1);
            }

            _description = value;
        }
    }

    public uint Size { get; set; } = 3;
    public virtual string Info => $"{Description} <{Size}>";

    public override string ToString()
    {
        return $"{this.GetType().Name.ToUpper()}: {Info}";
    }
}

public class Birds : Animals 
{
    public bool CanFly { get; set; } = true;

    public override string Info
    {
        get
        {
            string flyInfo = CanFly ? "(fly+)" : "(fly-)";
            return $"{Description} {flyInfo} <{Size}>";
        }

    }

}

