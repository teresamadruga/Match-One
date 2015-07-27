using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class AddViewSystem : IReactiveSystem {
    public IMatcher trigger { get { return Matcher.Resource; } }

    public GroupEventType eventType { get { return GroupEventType.OnEntityAdded; } }

    readonly Transform _viewContainer = new GameObject("Views").transform;

    public void Execute(List<Entity> entities) {

        Debug.Log("Add View");

        foreach (var e in entities) {
            var res = Resources.Load<GameObject>(e.resource.name);
            var gameObject = Object.Instantiate(res);
            gameObject.transform.SetParent(_viewContainer, false);
            e.AddView(gameObject);

            if (e.hasPosition) {
                var pos = e.position;
                gameObject.transform.position = new Vector3(pos.x, pos.y + 1, 0f);
            }
        }
    }
}