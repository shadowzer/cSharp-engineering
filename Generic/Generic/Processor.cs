using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    class Processor<TEngine, TEntity, TLogger>
    {

    }

    class ProcessorBuilder
    {
        public static Engine<TEngine> CreateEngine<TEngine>()
        {
            return new Engine<TEngine>();
        }
    }

    class Engine<TEngine>
    {
        public EngineEntity<TEngine, TEntity> For<TEntity>()
        {
            return new EngineEntity<TEngine, TEntity>();
        }
    }

    class EngineEntity<TEngine, TEntity>
    {
        public Processor<TEngine, TEntity, TLogger> With<TLogger>()
        {
            return new Processor<TEngine, TEntity, TLogger>();
        }
    }
}
