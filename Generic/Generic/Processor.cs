using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    class ProcessorBuilder<TEngine, TEntity, TLogger>
    {

    }

    class ProcessorWrapper
    {
        public static EngineWrapper<TEngine> CreateEngine<TEngine>()
        {
            return new EngineWrapper<TEngine>();
        }
    }

    class EngineWrapper<TEngine>
    {
        public EntityWrapper<TEngine, TEntity> For<TEntity>()
        {
            return new EntityWrapper<TEngine, TEntity>();
        }
    }

    class EntityWrapper<TEngine, TEntity>
    {
        public ProcessorBuilder<TEngine, TEntity, TLogger> With<TLogger>()
        {
            return new ProcessorBuilder<TEngine, TEntity, TLogger>();
        }
    }
}
