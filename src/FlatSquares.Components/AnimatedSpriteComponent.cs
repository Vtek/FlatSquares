using System;
using System.Collections.Generic;
using System.Linq;
using FlatSquares.Common;

namespace FlatSquares.Components
{
    public class AnimatedSpriteComponent : SpriteComponent, IUpdate
    {
        IDictionary<string, IEnumerable<Rectangle>> Animations { get; set; } = new Dictionary<string, IEnumerable<Rectangle>>();
        IEnumerable<Rectangle> Currents { get; set; }

        public float Duration { get; set; }

        bool _isFinish;
        int _index;
        float _elapsed;
        float _frameRate;

        public void AddAnimation(string key, params Rectangle[] rectangles)
        {
            Animations.Add(key, rectangles);
        }

        public void SetCurrent(string key)
        {
            Currents = Animations[key];
            Source = Animations[key].First();
            _frameRate = Duration / Currents.Count();
        }

        public void Reset()
        {
            _elapsed = 0f;
            _index = 0;
            _isFinish = false;
        }

        public void Update(float elapsed)
        {
            _elapsed += elapsed;

            if(!_isFinish)
            {
                if(_elapsed >= _frameRate) {
                    _index++;

                    if (_index < Currents.Count())
                        Source = Currents.ElementAt(_index);
                    else
                        _isFinish = true;

                    _elapsed = 0;
                }
            }
        }
    }
}
