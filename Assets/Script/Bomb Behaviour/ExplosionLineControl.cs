using Cysharp.Threading.Tasks;
using SotongStudio.Utilities.AudioSystem;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer.Unity;

namespace SotongStudio.Bomber
{
    public class ExplosionLineControl : MonoBehaviour
    {
        [SerializeField] private ExplosionLineView _view;


        private void Start()
        {
            SetExplosion();
        }

        private void SetExplosion()
        {
            StartCoroutine(BombCountdownCo());
        }

        IEnumerator BombCountdownCo()
        {
            BasicAudioSystem.Instance.PlaySFX("sumbu bomv2");
            yield return new WaitForSeconds(_view.BombDuration);
            BasicAudioSystem.Instance.PlaySFX("ledakan");
            _view.HideBomb();

            SetExplosionLine();

        }

        private void SetExplosionLine()
        {
            Vector2 bombPosition = _view.transform.position;
            Vector3 rotation = Vector3.zero;
            int prefabIndex = 0;
            Vector2 direction = Vector2.zero;
            int distance = 0;

            //middle line
            _view.ShowExplosion(prefabIndex, bombPosition, Vector3.zero);

            //extension & end
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j <= _view.BombLength; j++)
                {
                    if (i == 0)
                    {
                        bombPosition.x++;   //right
                        direction = Vector2.right;  //set raycast direction for wall detection
                    }
                    else if (i == 1)
                    {
                        bombPosition.y++;   //top
                        direction = Vector2.up;  //set raycast direction for wall detection
                    }
                    else if (i == 2)
                    {
                        bombPosition.x--;   //left
                        direction = Vector2.left;  //set raycast direction for wall detection
                    }
                    else if (i == 3)
                    {
                        bombPosition.y--;   //down
                        direction = Vector2.down;  //set raycast direction for wall detection
                    }

                    //ganti prefab ledakan
                    if (j == _view.BombLength)
                    {
                        prefabIndex = 2;
                    }
                    else
                    {
                        prefabIndex = 1;
                    }

                    //Flip extension
                    if (j % 2 == 0)
                    {
                        _view.Temp.GetComponent<SpriteRenderer>().flipY = true;
                    }
                    else
                    {
                        _view.Temp.GetComponent<SpriteRenderer>().flipY = false;
                    }

                    distance++; //nambah distance buat deteksi wall
                    _view.DetectWall(direction, distance);

                    if (_view._isHitWall)
                    {
                        break;
                    }
                    _view.ShowExplosion(prefabIndex, bombPosition, rotation);
                }

                //reset position
                bombPosition = _view.transform.position;
                distance = 0;
                _view._isHitWall = false;

                //rotate
                rotation.z += 90;

                StartCoroutine(ExplosionCountdownCo());
            }
        }

        IEnumerator ExplosionCountdownCo()
        {
            yield return new WaitForSeconds(_view.ExplosionDuration);
            _view.DestroyBomb();
        }


    }
}
