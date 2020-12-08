using System;
using System.Collections.Generic;

namespace Services.Implementations
{
    public class AuthResult<TKey>
        where TKey: IEquatable<TKey>
    {
        public TKey UserId { get; set; }
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
