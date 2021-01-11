﻿using System.Threading.Tasks;

namespace BlazoRx.Client
{
    public interface IRestClient
    {
        ValueTask<T> GetAsync<T>(string url);

        ValueTask<T> PostAsync<T>(string relativeUrl, object data);
    }
}