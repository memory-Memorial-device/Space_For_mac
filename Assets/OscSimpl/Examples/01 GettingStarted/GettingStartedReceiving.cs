/*
	Created by Carl Emil Carlsen.
	Copyright 2016-2020 Sixth Sensor.
	All rights reserved.
	http://sixthsensor.dk
*/

using UnityEngine;

namespace OscSimpl.Examples
{
	public class GettingStartedReceiving : MonoBehaviour
	{
		[SerializeField] OscIn _oscIn;

		const string address1 = "/test1";
		const string address2 = "/test2";
		const string address3 = "/test3";
		const string address4 = "/test4";

		public GameObject Camera;
		public bool PT01;
		public bool PT02;

		public int switch01;
		public int switch02;


		void Start()
		{
			// Ensure that we have a OscIn component and start receiving on port 7000.
			if (!_oscIn) _oscIn = gameObject.AddComponent<OscIn>();
			_oscIn.Open(7000);
			switch01 = 0;
			switch02 = 0;
		}


		void OnEnable()
		{
			// You can "map" messages to methods in two ways:

			// 1) For messages with a single argument, route the value using the type specific map methods.
			_oscIn.Map(address1, Appear_Particle);
			_oscIn.Map(address3, Appear_Particle_Two);
			_oscIn.Map(address4, Cancle);

			// 2) For messages with multiple arguments, route the message using the Map method.
			_oscIn.Map(address2, OnTest2);


		}


		void OnDisable()
		{
			// If you want to stop receiving messages you have to "unmap".
			//_oscIn.UnmapFloat(OnTest1);
			//_oscIn.Unmap(OnTest2);
		}


		void OnTest1(float value)
		{
			Debug.Log("Received test1\n" + value + "\n"); // Composing strings like this generates garbage, use StringBuider IRL.
		}


		void OnTest2(OscMessage message)
		{
			// Get arguments from index 0, 1 and 2 safely.
			float pos_x;
			float pos_y;
			float pos_z;
			float rotate_X, rotate_Y, rotate_Z;
			if (
				message.TryGet(0, out pos_x) &&
				message.TryGet(1, out pos_y) &&
				message.TryGet(2, out pos_z) &&
				message.TryGet(3, out rotate_X) &&
				message.TryGet(4, out rotate_Y) &&
				message.TryGet(5, out rotate_Z)
			)
			{
				Debug.Log("Received test2\n" + pos_x + " " + pos_y + " " + pos_z + "\n");
				Camera.transform.position = new Vector3(pos_x, pos_y, pos_z);
				float degreeX, degreeY, degreeZ;
				Camera.transform.rotation = Quaternion.Euler(rotate_X, rotate_Y, 360.0f - rotate_Z);
			}

			OscPool.Recycle(message);
		}

		void Appear_Particle(OscMessage message)
        {
			switch01 = 1;
			switch02 = 0;
		}

		void Appear_Particle_Two(OscMessage message)
		{
			switch01 = 0;
			switch02 = 1;
		}

		void Cancle(OscMessage message)
		{
			switch01 = 0;
			switch02 = 0;
		}

	}
}