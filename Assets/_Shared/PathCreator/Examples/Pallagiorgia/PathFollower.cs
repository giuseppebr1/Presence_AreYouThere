using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;


namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        public float duration = 5;
        float distanceTravelled;

        void Start() {

            //NEW VERSION
            
            //List<Vector3> pathPoints = GetPathPoints(pathCreator, 100);
            //transform.position = pathPoints[0];
            //transform.DOPath(pathPoints.ToArray(),duration).OnComplete(() => 
            //{
            //    OnSpherePathComplete();
            //});

            //return;

            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }

        }

        void Update()
        {

            //return;

            //OLD VERSION
            if (pathCreator != null)
            {
                //transform.rotation= Quaternion.Euler(transform.rotation.eulerAngles.x , transform.rotation.eulerAngles.y)
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                //transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }

        void OnSpherePathComplete() 
        { 

        
        }

        public List<Vector3> GetPathPoints(PathCreator path, int resolution)
        {
            List<Vector3> points = new List<Vector3>();

            //DEBUG
            //GameObject root = new GameObject("Root");
            //root.transform.position = Vector3.zero;
            //root.transform.rotation = Quaternion.identity;


            for (int i = 0; i < resolution; i++)
            {
                float distance = i * (pathCreator.path.length / resolution);
                if (i == resolution)
                    distance = pathCreator.path.length - 0.001f;

                Vector3 point = pathCreator.path.GetPointAtDistance(distance);


                points.Add(point);

                //DEBUG
                //GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                //go.transform.position = point;
                //go.transform.rotation = Quaternion.identity;
                //go.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                //go.transform.parent = root.transform;

            }
            return points;
        }

    }
}