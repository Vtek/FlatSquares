using System.Collections.Generic;
using System.Linq;
using FlatSquares.Common;

namespace FlatSquares.Components
{
    /// <summary>
    /// Animated sprite component.
    /// </summary>
    public class AnimatedSpriteComponent : SpriteComponent, IUpdate
    {
        IDictionary<string, IEnumerable<Rectangle>> Animations { get; set; } = new Dictionary<string, IEnumerable<Rectangle>>();
        IEnumerable<Rectangle> Currents { get; set; }
        bool _isFinished;
        int _index;
        float _elapsed;
        float _frameRate;

        /// <summary>
        /// Gets or sets the duration (in seconds).
        /// </summary>
        /// <value>The duration.</value>
        public float Duration { get; set; }

        /// <summary>
        /// Add an animation.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="rectangles">Source rectangles.</param>
        public void AddAnimation(string key, params Rectangle[] rectangles) => Animations.Add(key, rectangles);

        /// <summary>
        /// Set current animation.
        /// </summary>
        /// <param name="key">Key.</param>
        public void SetCurrent(string key)
        {
            Currents = Animations[key];
            _frameRate = Duration / Currents.Count();
        }

        /// <summary>
        /// Launch the current animation.
        /// </summary>
        public void Launch()
        {
            _elapsed = 0f;
            _index = 0;
            _isFinished = false;
            Source = Currents.First();
        }

        /// <summary>
        /// Stop this current animation.
        /// </summary>
        public void Stop()
        {
            _isFinished = true;
            Source = Rectangle.Empty;
        }

        /// <summary>
        /// Initialize this instance.
        /// </summary>
        public override void Initialize() => Stop();

        /// <summary>
        /// Perform an update.
        /// </summary>
        /// <param name="elapsed">Elapsed time since last update.</param>
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
                        Stop();
                }
            }
        }
    }
}
