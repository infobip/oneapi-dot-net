namespace org.oneapi.model
{

	/// 
	/// <summary>
	/// @author vavukovic
	/// 
	/// </summary>
	public class CaptchaRequest
	{
		private int width;
		private int height;
		private string format;

		public CaptchaRequest()
		{
		}

		public CaptchaRequest(int width, int height, string format)
		{
			this.width = width;
			this.height = height;
			this.format = format;
		}

		public virtual int Width
		{
			get
			{
				return width;
			}
			set
			{
				this.width = value;
			}
		}


		public virtual int Height
		{
			get
			{
				return height;
			}
			set
			{
				this.height = value;
			}
		}


		public virtual string Format
		{
			get
			{
				return format;
			}
			set
			{
				this.format = value;
			}
		}

	}

}