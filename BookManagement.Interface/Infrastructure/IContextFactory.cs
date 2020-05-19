using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagement.Interface.Infrastructure
{
    /// <summary>
    /// Context factory for creation of context
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public interface IContextFactory<out TContext> where TContext: DbContext
    {
        /// <summary>
        /// Create new database context
        /// </summary>
        /// <returns></returns>
        TContext Create();
    }
}
