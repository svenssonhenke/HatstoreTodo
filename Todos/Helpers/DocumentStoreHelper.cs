using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Todos.Helpers
{
    public static class DocumentStoreHelper
    {
        public static IDocumentStore Store => LazyStore.Value;

        private static readonly Lazy<IDocumentStore> LazyStore = new Lazy<IDocumentStore>(() =>
       {
           var store = new DocumentStore
           {
               ConnectionStringName = "RavenConnection",
               DefaultDatabase = "Todos"
           };

           return store.Initialize();
       });
    }
}