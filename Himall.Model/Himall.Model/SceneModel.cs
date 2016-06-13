using System;

namespace Himall.Model
{
	public class SceneModel
	{
		private QR_SCENE_Type _type;

		public QR_SCENE_Type SceneType
		{
			get
			{
				return this._type;
			}
			set
			{
				this._type = value;
			}
		}

		public object Object
		{
			get;
			set;
		}

		public SceneModel(QR_SCENE_Type type)
		{
			this._type = type;
		}

		public SceneModel(QR_SCENE_Type type, object obj)
		{
			this._type = type;
			this.Object = obj;
		}
	}
}
