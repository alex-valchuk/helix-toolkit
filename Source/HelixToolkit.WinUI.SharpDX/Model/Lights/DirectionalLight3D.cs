﻿using HelixToolkit.SharpDX.Model.Scene;
using HelixToolkit.WinUI.SharpDX.Model;
using SharpDX;

namespace HelixToolkit.WinUI.SharpDX;

public sealed class DirectionalLight3D : Light3D
{
    public static readonly DependencyProperty DirectionProperty =
        DependencyProperty.Register("Direction", typeof(Vector3), typeof(Light3D), new PropertyMetadata(new Vector3(),
            (d, e) =>
            {
                if (d is Element3DCore element && element.SceneNode is DirectionalLightNode node)
                {
                    node.Direction = ((Vector3)e.NewValue);
                }
            }));

    /// <summary>
    /// Direction of the light.
    /// It applies to Directional Light and to Spot Light,
    /// for all other lights it is ignored.
    /// </summary>
    public Vector3 Direction
    {
        get { return (Vector3)this.GetValue(DirectionProperty); }
        set { this.SetValue(DirectionProperty, value); }
    }

    protected override SceneNode OnCreateSceneNode()
    {
        return new DirectionalLightNode();
    }

    protected override void AssignDefaultValuesToSceneNode(SceneNode core)
    {
        base.AssignDefaultValuesToSceneNode(core);

        if (core is DirectionalLightNode lightNode)
        {
            lightNode.Direction = Direction;
        }
    }
}