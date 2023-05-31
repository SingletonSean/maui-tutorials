using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockedMode.Features.ViewRandomCatFact.Mock
{
    public class MockRandomCatFactQuery : IRandomCatFactQuery
    {
        private static readonly List<CatFact> CAT_FACTS = new List<CatFact>()
        {
            new CatFact() { Content = "Cats are awesome." },
            new CatFact() { Content = "Cats catch mice." },
            new CatFact() { Content = "Cats like to sleep." }
        };

        public Task<CatFact> Execute()
        {
            int randomCatFactIndex = new Random().Next(CAT_FACTS.Count);
            CatFact randomCatFact = CAT_FACTS[randomCatFactIndex];

            return Task.FromResult(randomCatFact);
        }
    }
}
