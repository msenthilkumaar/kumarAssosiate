using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SQLParam
{
    string param = "", paramVal = "";

    public SQLParam(string ListText, string ListValue)
    {
        this.param = ListText;
        this.paramVal = ListValue;
    }

    public string ParameterName
    {
        get { return param; }
        set { param = value; }
    }

    public string ParameterValue
    {
        get { return paramVal; }
        set { paramVal = value; }
    }

    public override string ToString()
    {
        return ParameterValue;
    }

}
