using System.Collections.Generic;
using System.Linq;
using FlatSquares.Common;

namespace FlatSquares.Components
{
    public class AnimatedSpriteComponent : SpriteComponent, IUpdate
    {
        IDictionary<string, IEnumerable<Rectangle>> Animations { get; set; } = new Dictionary<string, IEnumerable<Rectangle>>();
        IEnumerable<Rectangle> Currents { get; set; }
        bool _isFinished = true;
        int _index;
        float _elapsed;
        float _frameRate;

        public float Duration { get; set; }

        public void AddAnimation(string key, params Rectangle[] rectangles)
        {
            Animations.Add(key, rectangles);
        }

        public void SetCurrent(string key)
        {
            Currents = Animations[key];
            _frameRate = Duration / Currents.Count();
        }

        public void Launch()
        {
            _elapsed = 0f;
            _index = 0;
            _isFinished = false;
            Source = Currents.First();
        }

        public override void Initialize() => Source = Rectangle.Empty;

        public void Update(float elapsed)
        {
            if (!_isFinished)
            {
                _elapsed += elapsed;

                if (_elapsed >= _frameRate)
                {
                    _index++;

                    if (_index < Currents.Count())
                        Source = Currents.ElementAt(_index);
                    else
                        _isFinished = true;

                    _elapsed = 0;
                }
            }
        }
    }
}
