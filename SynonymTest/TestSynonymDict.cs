using Synonyms.Models;
using Xunit;

namespace SynonymTest
{
    public class TestSynonymDict
    {
        private SynonymDict _Synonyms;

        public TestSynonymDict() 
        {
            _Synonyms = new SynonymDict();
        }

        [Fact]
        public void SingleAdd()
        {
            _Synonyms.Add("cake", "deliciousness");

            Assert.Contains("deliciousness", _Synonyms.GetSynonyms("cake"));
            Assert.Contains("cake", _Synonyms.GetSynonyms("deliciousness"));
        }

        [Fact]
        public void MultipleAdd()
        {
            List<string> list = new List<string> 
            {
                "deliciousness",
                "magic",
                "dreams"
            };

            _Synonyms.Add("cake", list);

            Assert.Equal(_Synonyms.GetSynonyms("cake"), list);
            
            Assert.Contains("cake", _Synonyms.GetSynonyms("deliciousness"));
            Assert.Contains("cake", _Synonyms.GetSynonyms("magic"));
            Assert.Contains("cake", _Synonyms.GetSynonyms("dreams"));
        }

        [Fact]
        public void Sync()
        {
            _Synonyms.Add("cake", new List<string>
            {
                "magic"
            });

            _Synonyms.Add("deliciousness", new List<string>
            {
                "dreams"
            });

            _Synonyms.Add("cake", "deliciousness");

            Assert.Contains("magic", _Synonyms.GetSynonyms("deliciousness"));
            Assert.Contains("dreams", _Synonyms.GetSynonyms("cake"));

            Assert.Contains("dreams", _Synonyms.GetSynonyms("magic"));
            Assert.Contains("deliciousness", _Synonyms.GetSynonyms("magic"));
        }
    }
}