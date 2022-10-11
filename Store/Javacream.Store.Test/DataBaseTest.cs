using Javacream.Store.Impl;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javacream.Store.Test;
public class DataBaseTest
{
    [Test]
    public void DbTest()
    {
        DataBaseDemo dataBaseDemo = new DataBaseDemo();
        dataBaseDemo.DoDemo();

    }

}
