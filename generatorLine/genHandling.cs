using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using addVehicle.Model;

namespace addVehicle.generatorLinee
{
    public class genHandling
    {
        public Task<Generator> start(Info info)
        {
            string path = $"{info.pathGta}\\data\\handling.cfg";
            Generator generator = new Generator();
            var lines = File.ReadAllLines(path).ToArray();
            for (var i = 0; i < lines.Length; i += 1)
            {
                var line = lines[i];
                if(line.Contains(info.nameVehicleToCopy))
                {
                    generator.line = line;
                    generator.result = true;
                    break;
                }
            }
            return Task.FromResult(generator);
        }
    }
}
