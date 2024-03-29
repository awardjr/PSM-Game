using System;
using System.Collections;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.Core.Environment;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

using Sce.PlayStation.HighLevel.Physics2D;


	public class PhysicalSpriteUV : SpriteUV
	{
		public PhysicalSpriteUV (TextureInfo textureInfo, PhysicsScene physicsScene, bool circle = false) : base(textureInfo)
		{
			// Texture Setup
			Quad.S = TextureInfo.TextureSizef;
			Pivot = new Vector2(TextureInfo.Texture.Width / 2f, TextureInfo.Texture.Height / 2f );
		
			// Physics Setup (get the indicies we will be using
			PhysicsScene = physicsScene;
			ShapeIndex = PhysicsScene.NumShape;
			BodyIndex = PhysicsScene.NumBody;
			JointIndex = -1;
		
			// Create shapes (will want to let the programmer pass in things like friction and rotation at some point, AND SPECIFY CIRCLE OR SQUARE SHAPE)
			PhysicsShape shape;
			if(!circle)
			{
				shape = new PhysicsShape(new Vector2(textureInfo.Texture.Width/2, textureInfo.Texture.Height/2));
			}
			else
			{
				shape = new PhysicsShape(textureInfo.Texture.Width/2);				
			}
		
			// Why 100?
			PhysicsBody body = new PhysicsBody(shape, 100);
			body.ShapeIndex = (uint)ShapeIndex;
		
			PhysicsScene.sceneShapes[ShapeIndex] = shape;
			PhysicsScene.sceneBodies[BodyIndex] = body;
			//PhysicsScene.sceneBodies[BodyIndex].Rotation = 0.1f;
			//PhysicsScene.sceneBodies[BodyIndex].AirFriction = 0.01f;

			PhysicsScene.NumShape++;
			PhysicsScene.NumBody++;
		}
	
		public bool AddJoint(uint bodyIndex)
		{
			if(Joined) return false;
		
			PhysicsBody b1 = PhysicsScene.sceneBodies[BodyIndex];
			PhysicsBody b2 = PhysicsScene.sceneBodies[bodyIndex];
			JointIndex = PhysicsScene.NumJoint;
			PhysicsScene.sceneJoints[JointIndex] = new PhysicsJoint(b1, b2, (b1.position), (uint)BodyIndex, (uint)bodyIndex);
			PhysicsScene.sceneJoints[JointIndex].axis1Lim = new Vector2(1, 0);
			PhysicsScene.sceneJoints[JointIndex].axis2Lim = new Vector2(0, 1);
			PhysicsScene.sceneJoints[JointIndex].angleLim = 1;
			PhysicsScene.numJoint++;
			
			return true;
		}
	
		public bool RemoveJoint()
		{
			if(!Joined) return false;
		
			PhysicsScene.sceneJoints[JointIndex] = PhysicsScene.sceneJoints[PhysicsScene.NumJoint - 1];
			PhysicsScene.sceneJoints[PhysicsScene.NumJoint - 1] = null;
			PhysicsScene.numJoint--;
			JointIndex = -1;
		
			return true;
		}
	
		public bool Intersects(uint bodyIndex)
		{
			return PhysicsScene.QueryContact((uint)BodyIndex, bodyIndex);
		}
	
		public override void Update(float dt)
		{
			PositionTexture = PositionPhysics - Pivot;
			AngleTexture = AnglePhysics;
		
			base.Update(dt);
		}
		
		public Vector2 PositionAll { set { Position = value; PhysicsScene.SceneBodies[BodyIndex].Position = value; } }
		public Vector2 PositionPhysics { get{ return PhysicsScene.SceneBodies[BodyIndex].Position; } set { PhysicsScene.SceneBodies[BodyIndex].Position = value; } }
		public Vector2 PositionTexture { get{ return Position; } set { Position = value; } }
		public float AngleAll { set { Angle = value; PhysicsScene.SceneBodies[BodyIndex].Rotation = value; } }
		public float AnglePhysics { get { return PhysicsScene.SceneBodies[BodyIndex].Rotation; } set { PhysicsScene.SceneBodies[BodyIndex].Rotation = value; } }
		public float AngleTexture { get { return Angle; } set { Angle = value; } }
		public PhysicsScene PhysicsScene { get; set; }
		public int ShapeIndex { get; set; }
		public int BodyIndex { get; set; }
		public int JointIndex { get; set; }
		public bool Joined { get { return JointIndex != -1; } }
	}
