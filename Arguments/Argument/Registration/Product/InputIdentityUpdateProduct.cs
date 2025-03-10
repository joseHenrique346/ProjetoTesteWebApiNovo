﻿using Arguments.Argument.Base.Crud;

namespace Arguments.Argument.Registration.Product
{
    public class InputIdentityUpdateProduct : BaseInputIdentityUpdate<InputIdentityUpdateProduct>
    {
        public long Id { get; private set; }
        public InputUpdateProduct InputUpdateProduct { get; private set; }
    }
}
