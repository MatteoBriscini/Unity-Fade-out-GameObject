using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities.Fade {
    public class FadingObject : MonoBehaviour, IEquatable<FadingObject> {
        public List<Renderer> Renderers = new List<Renderer>();
        public Vector3 _position;
        public List<Material> Materials = new List<Material>();
        [HideInInspector]
        public float InitialAlpha;

        private void Awake() {
            _position = transform.position;
            if (Renderers.Count == 0) {
                Renderers.AddRange(GetComponentsInChildren<Renderer>());
            }
            for (int i = 0; i < Renderers.Count; i++) {
                Materials.AddRange(Renderers[i].materials);
            }

            InitialAlpha = Materials[0].color.a;
        }

        public bool Equals(FadingObject other) {
            return _position.Equals(other._position);
        }

        public override int GetHashCode() {
            return _position.GetHashCode();
        }
    }
}