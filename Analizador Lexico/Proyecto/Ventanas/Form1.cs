using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace WindowsApplication1
{
	/// <summary>
	/// Descripción breve de Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		#region Variables de la clase

		CCompoLex objCCompoLex;

		#endregion
		
		#region Controles de la ventana
		
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtCadena;
		private System.Windows.Forms.ListView lstvInfo;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Button button3;
		
		#endregion
		private System.Windows.Forms.Button button4;

		#region Constructores

		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Necesario para admitir el Diseñador de Windows Forms
			//
			InitializeComponent();

			//
			// TODO: agregar código de constructor después de llamar a InitializeComponent
			//
		}


		#endregion

		#region Codigo generado por el diseñador de ventanas

		/// <summary>
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

			
		#region Código generado por el Diseñador de Windows Forms
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.txtCadena = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lstvInfo = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(336, 144);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(120, 40);
			this.button1.TabIndex = 2;
			this.button1.Text = "&Otra Expresion";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(336, 88);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(120, 40);
			this.button2.TabIndex = 1;
			this.button2.Text = "&Analisis Lexico";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// txtCadena
			// 
			this.txtCadena.Location = new System.Drawing.Point(8, 32);
			this.txtCadena.Multiline = true;
			this.txtCadena.Name = "txtCadena";
			this.txtCadena.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtCadena.Size = new System.Drawing.Size(448, 40);
			this.txtCadena.TabIndex = 0;
			this.txtCadena.Text = "";
			this.txtCadena.TextChanged += new System.EventHandler(this.txtCadena_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(174, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Introduzca Cadena de Caracteres";
			// 
			// lstvInfo
			// 
			this.lstvInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					   this.columnHeader1,
																					   this.columnHeader2});
			this.lstvInfo.GridLines = true;
			this.lstvInfo.Location = new System.Drawing.Point(8, 80);
			this.lstvInfo.Name = "lstvInfo";
			this.lstvInfo.Size = new System.Drawing.Size(272, 272);
			this.lstvInfo.TabIndex = 4;
			this.lstvInfo.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Lexema";
			this.columnHeader1.Width = 178;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Token";
			this.columnHeader2.Width = 87;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(336, 200);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(120, 40);
			this.button3.TabIndex = 3;
			this.button3.Text = "&Mostrar Tablas";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(336, 256);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(120, 40);
			this.button4.TabIndex = 5;
			this.button4.Text = "&Salir";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(464, 388);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.lstvInfo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtCadena);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button3);
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Analizador Lexico";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#endregion

		#region Funciones Personalizadas
			
		public string analizadorLexico ()
		{			
			int iAm = 0;
			int iAf = 0;			
			bool bConcordancia = false;			
			string sCadEntrada = this.txtCadena.Text;
			string sLexema = string.Empty;
			string sToken  = string.Empty;
			string sRes    = string.Empty;
			string sRes2   = string.Empty;

			CBuscarConcordancia objCBuscarConcordancia = new CBuscarConcordancia ();
			CAnalizadorLexico objAnalizadorLexico = new CAnalizadorLexico ();
			lstvInfo.Items.Clear ();

			if ( this.txtCadena.Text != string.Empty )
			{
		
				while ( sRes != "EOF")
				{
					bConcordancia = objAnalizadorLexico.buscarConcordancia( sCadEntrada + "\x0", ref iAf, ref iAm, out sRes, out sRes2 );
					
					if (bConcordancia)
					{
						sLexema = string.Empty;
						sLexema = CAnalizadorLexico.extraerLexema ( sCadEntrada, ref iAf, ref iAm);
						
						switch ( sRes )
						{
								//Token Lexema Numeros
							case "Numero":								
								sToken = objAnalizadorLexico.tokenLexema ( sLexema, sRes, sRes2, "Numeros" );
								break;
								//Token Lexema Identificador
							case "Identificador":
								sToken = objAnalizadorLexico.tokenLexema ( sLexema, "Identificador");
								break;
							default:
								sToken = "";
								break;
						}
																		
						if ( sToken == string.Empty )
						{
							sToken = objAnalizadorLexico.tokenLexema ( sCadEntrada, sLexema, ref iAf, ref iAm );
							//Token de un Simbolo Reconocido
							mostrarTokenLexema ( lstvInfo, sLexema, sToken );
						}
						else
						{
							//Token de un Simbolo Reconocido
							mostrarTokenLexema ( lstvInfo, sLexema, sToken );
						}						
						bConcordancia = true;
						iAf = iAm;//Igualar la posicion de los dos apuntadores
					}
					else
					{
					}		
				}//Fin While

				//Regresar Token Fin de Archivo
				mostrarTokenLexema ( lstvInfo, "EOF", "(0,0)" );
			}
			else
			{
				MessageBox.Show ( "Cadena Vacia intentelo otra vez" );
			}
			
			sToken = "Cadena Vacia";
			return sToken;
		}

		/// <summary>
		/// Agrega el Token junto con su correspondiente Lexema al Control ListView
		/// </summary>
		/// <param name="parLstVw">Control a agregar la informacion</param>
		/// <param name="parsLexema">Lexema a agregar</param>
		/// <param name="parsToken">Token del Lexema a agregar</param>
		private void mostrarTokenLexema ( System.Windows.Forms.ListView parLstVw, string  parsLexema, string parsToken )
		{
			string sLexema = parsLexema;
			string sToken  = parsToken;
			int iLen = 0;
			System.Windows.Forms.ListView lstInfo = parLstVw;
			iLen = lstInfo.Items.Count;

			if ( sLexema != " " && sLexema != "\n" && sLexema != "\t" && sLexema != "\r")
			{
				lstInfo.Items.Add(sLexema.ToString());
				lstInfo.Items[iLen].SubItems.Add(sToken.ToString());
			}
				//Token Fin de Archivo
			else if ( sLexema == "Fin Archivo" )
			{
				lstInfo.Items.Add(sLexema.ToString());
				lstInfo.Items[iLen].SubItems.Add("EOF");
			}
		}


		#endregion

		#region Metodo Principal

		/// <summary>
		/// Punto de entrada principal de la aplicación.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}


		#endregion
		
		#region Eventos de los controles	

		private void Form1_Load(object sender, System.EventArgs e)
		{
			objCCompoLex = new CCompoLex ();
			CCompoLex.iIdentificador            = new ArrayList ();	
			CCompoLex.NumerosEnteros            = new  ArrayList ();
			CCompoLex.NumerosFlotantes          = new ArrayList ();
			CCompoLex.NumerosNotacionCientifica = new ArrayList ();
		}

		private void textBox1_TextChanged(object sender, System.EventArgs e)
		{			
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			txtCadena.Clear ();
			lstvInfo.Items.Clear ();
			CCompoLex.iIdentificador.Clear ();
			CCompoLex.NumerosEnteros.Clear ();
			CCompoLex.NumerosFlotantes.Clear ();
			CCompoLex.NumerosNotacionCientifica.Clear ();
			this.txtCadena.Focus ();
			
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			Form2 FormDialog = new Form2();
			FormDialog.ShowDialog (this);
		}

		private void txtCadena_TextChanged(object sender, System.EventArgs e)
		{
			
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			analizadorLexico ();
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			this.Close ();
		}

		#endregion
	}
}
