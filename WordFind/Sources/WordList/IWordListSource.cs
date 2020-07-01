using System.Collections.Generic;

namespace WordFind.Sources.WordList
{
    public interface IWordListSource
    {
        IEnumerable<string> Words();
    }
}