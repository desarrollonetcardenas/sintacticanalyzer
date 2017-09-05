/* Descripcion: 
 *	Archivo que muestra toda la tabla de componentes lexicos
 * Fecha de creacion: 08 de Octubre del 2007
 * Modificaciones:
 * Motivo:
 * Modificado por:
 * 
 * */

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsApplication1
{
	/// <summary>
	/// Descripción breve de Form2.
	/// </summary>
	public class Form2 : System.Windows.Forms.Form
	{
		#region Variables de la clase

		CCompoLex lexema;

		#endregion
		
		
		#region Controles de la ventana

		private System.Windows.Forms.ListView lstUno;
		private System.Windows.Forms.ColumnHeader columnHeader1;		
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ListBox lstbxTablas;

		#endregion

		#region Contructores

		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form2()
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
				if(components != null)
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
			this.lstUno = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.lstbxTablas = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// lstUno
			// 
			this.lstUno.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					 this.columnHeader1,
																					 this.columnHeader4});
			this.lstUno.GridLines = true;
			this.lstUno.Location = new System.Drawing.Point(0, 8);
			this.lstUno.MultiSelect = false;
			this.lstUno.Name = "lstUno";
			this.lstUno.Size = new System.Drawing.Size(184, 264);
			this.lstUno.TabIndex = 0;
			this.lstUno.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Lexemas";
			this.columnHeader1.Width = 110;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Token";
			// 
			// lstbxTablas
			// 
			this.lstbxTablas.Items.AddRange(new object[] {
															 "Palabras Reservadas",
															 "Operadores Aritmeticos",
															 "Operadores Relacionales",
															 "Operadores Logicos",
															 "Parentesis Circular",
															 "Parentesis Cuadrado",
															 "Llaves",
															 "Identificadores",
															 "Numeros Enteros",
															 "Numeros Reales",
															 "Numeros Notacion Cientifica",
															 "Operador de Asignacion"});
			this.lstbxTablas.Location = new System.Drawing.Point(192, 8);
			this.lstbxTablas.Name = "lstbxTablas";
			this.lstbxTablas.Size = new System.Drawing.Size(168, 264);
			this.lstbxTablas.TabIndex = 1;
			this.lstbxTablas.SelectedIndexChanged += new System.EventHandler(this.lstbxTablas_SelectedIndexChanged);
			// 
			// Form2
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(370, 292);
			this.Controls.Add(this.lstbxTablas);
			this.Controls.Add(this.lstUno);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "Form2";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Tabla de Componentes Lexicos";
			this.Load += new System.EventHandler(this.Form2_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#endregion

		#region Funciones personalizadas							

		private void addColumna ( System.Windows.Forms.ListView parLstVw )
		{
			System.Windows.Forms.ListView lstUno = parLstVw;
			
			lstUno.Items.Add ( "Columna 1" );
			lstUno.Items.Add ( "Columna 2" );
			lstUno.Items.Add ( "Columna 3" );
			lstUno.Items.Add ( "Columna 4" );

			lstUno.Items[0].SubItems[0].Text = "Valor 1";
			//lstUno.Items[0].SubItems[1].Add ( "Valor 2");
			//lstUno.Items[0].SubItems[1].Add ( "Valor 3");
			//lstUno.Items[1].SubItems[1].Add ( "Valor 4");
			//lstUno.Items[1].SubItems[1].Add ( "Valor 5");
			
			lstUno.View = View.Details;
		}
		
		private void clearItemsLstVw ( System.Windows.Forms.ListView parLstVw, int numItems )
		{
			int i    = 0;
			int iMax = numItems;
			System.Windows.Forms.ListView lstUno = parLstVw;

			for ( i=0; i < numItems; i++ )
			{
				lstUno.Items[i].SubItems.Clear();
			}
		}
						
		private void loadNumeros ( System.Collections.ArrayList parobjArrayList, System.Windows.Forms.ListView parLstVw )
		{			
			int i = 0;
			System.Windows.Forms.ListView lstUno = parLstVw;
			System.Collections.ArrayList objArrayList = parobjArrayList;
			
			lstUno.Items.Clear ();

			for ( i=0; i < objArrayList.Count; i++ )
			{
				lstUno.Items.Add (objArrayList[i].ToString ());
			}
		}
		
		private void loadNumerosEnteros (System.Windows.Forms.ListView parLstVw )
		{			
			int i = 0;
			System.Windows.Forms.ListView lstUno = parLstVw;
			lstUno.Items.Clear ();

			for ( i=0; i < CCompoLex.NumerosEnteros.Count; i++ )
			{
				lstUno.Items.Add (CCompoLex.NumerosEnteros[i].ToString ());
			}
		}

		private void loadNumerosReales (System.Windows.Forms.ListView parLstVw )
		{			
			int i = 0;
			System.Windows.Forms.ListView lstUno = parLstVw;
			lstUno.Items.Clear ();

			for ( i=0; i < CCompoLex.NumerosFlotantes.Count; i++ )
			{
				lstUno.Items.Add (CCompoLex.NumerosFlotantes[i].ToString ());
			}
		}

		private void loadNumerosNotacionCientifica (System.Windows.Forms.ListView parLstVw )
		{			
			int i = 0;
			System.Windows.Forms.ListView lstUno = parLstVw;
			lstUno.Items.Clear ();

			for ( i=0; i < CCompoLex.NumerosNotacionCientifica.Count; i++ )
			{
				lstUno.Items.Add (CCompoLex.NumerosNotacionCientifica[i].ToString ());
			}
		}

		private void loadIdentificadores ( System.Windows.Forms.ListView parLstVw )
		{
			System.Windows.Forms.ListView lstUno = parLstVw;
			
			lstUno.Items.Clear ();
			
			for ( int i=0; i<CCompoLex.iIdentificador.Count; i++ )
			{						
				try
				{
					lstUno.Items.Add ( CCompoLex.iIdentificador[i].ToString ());	
				}
				catch ( Exception ex)
				{
					throw (ex);
				}
			}
		}

		private void loadPalabrasReservadas ( System.Windows.Forms.ListView parLstVw )
		{
			int i = 0;
			System.Windows.Forms.ListView lstUno = parLstVw;
						
			lstUno.Items.Clear ();

			for ( i=0; i < lexema.sPalReservadas.Length; i++ )
			{
				lstUno.Items.Add (lexema.sPalReservadas[i].ToString() );
			}
		}

		private void loadOperadoresAritmeticos ( System.Windows.Forms.ListView parLstVw )
		{
			int i = 0;
			System.Windows.Forms.ListView lstUno = parLstVw;		
			lstUno.Items.Clear ();
			
			for ( i=0; i < lexema.sOpAritmeticos.Length; i++ )
			{
				lstUno.Items.Add (lexema.sOpAritmeticos[i].ToString());
			}

		}

		private void loadOperadoresRelacionales ( System.Windows.Forms.ListView parLstVw )
		{
			int i = 0;
			System.Windows.Forms.ListView lstUno = parLstVw;		
			lstUno.Items.Clear ();

			for ( i=0; i < lexema.sOpRelacionales.Length; i++ )
			{
				lstUno.Items.Add (lexema.sOpRelacionales[i].ToString());
			}
		}

		private void loadOperadoresLogicos ( System.Windows.Forms.ListView parLstVw )
		{
			int i = 0;
			System.Windows.Forms.ListView lstUno = parLstVw;		

			lstUno.Items.Clear ();
			
			for ( i=0; i < lexema.sOpLogicos.Length; i++ )
			{
				lstUno.Items.Add (lexema.sOpLogicos[i].ToString());
			}
			
		}

		private void loadParentesisCircular ( System.Windows.Forms.ListView parLstVw )
		{
			int i = 0;
			System.Windows.Forms.ListView lstUno = parLstVw;		

			lstUno.Items.Clear ();
			
			for ( i=0; i < lexema.sParCircular.Length; i++ )
			{
				lstUno.Items.Add (lexema.sParCircular[i].ToString());
			}
		
		}
		private void loadParentesisCuadrado ( System.Windows.Forms.ListView parLstVw )
		{
			int i = 0;
			System.Windows.Forms.ListView lstUno = parLstVw;		

			lstUno.Items.Clear ();
			
			for ( i=0; i < lexema.sParCuadrado.Length; i++ )
			{
				lstUno.Items.Add (lexema.sParCuadrado[i].ToString());
			}
		
		}

		private void loadLlaves ( System.Windows.Forms.ListView parLstVw )
		{
			int i = 0;
			System.Windows.Forms.ListView lstUno = parLstVw;		

			lstUno.Items.Clear ();
			
			for ( i=0; i < lexema.sLlaves.Length; i++ )
			{
				lstUno.Items.Add (lexema.sLlaves[i].ToString());
			}			
		}
		
		private void loadOperadorAsignacion ( System.Windows.Forms.ListView parLstVw )
		{			
			System.Windows.Forms.ListView lstUno = parLstVw;
			lstUno.Items.Clear ();
			lstUno.Items.Add ("=");
		}
		
		/// <summary>
		/// Carga sus Tokens de Acuerdo al Id de tabla proporcionado
		/// </summary>
		/// <param name="parLstVw">Control donde se agregan los Tokens</param>
		/// <param name="pariIdTabla">Numero de Tabla a agregar sus Tokens</param>
		private void loadTokens ( System.Windows.Forms.ListView parLstVw, int pariIdTabla )
		{
			int iId = pariIdTabla;
			int i = 0;
			System.Windows.Forms.ListView lstUno = parLstVw;


			switch ( iId )
			{				
				//Palabras Reservadas
				case 1:
					for ( i=0; i<lexema.sPalReservadas.Length; i++)
					{
						lstUno.Items[i].SubItems.Add("(" + iId.ToString () + "," + i.ToString() + ")");
					}
					break;
					//Operadores Aritmeticos
				case 2:
					for ( i=0; i<lexema.sOpAritmeticos.Length; i++)
					{
						lstUno.Items[i].SubItems.Add("(" + iId.ToString () + "," + i.ToString() + ")");
					}
					break;
					//Operadores Relacionales
				case 3:
					for ( i=0; i<lexema.sOpRelacionales.Length; i++)
					{
						lstUno.Items[i].SubItems.Add("(" + iId.ToString () + "," + i.ToString() + ")");
					}
					break;
					//Operadores Logicos
				case 4:
					for ( i=0; i<lexema.sOpLogicos.Length; i++)
					{
						lstUno.Items[i].SubItems.Add("(" + iId.ToString () + "," + i.ToString() + ")");
					}
					break;
					//Parentesis Circular
				case 5:
					for ( i=0; i<lexema.sParCircular.Length; i++)
					{
						lstUno.Items[i].SubItems.Add("(" + iId.ToString () + "," + i.ToString() + ")");
					}
					break;
					//Parentesis Cuadrado
				case 6:
					for ( i=0; i<lexema.sParCuadrado.Length; i++)
					{
						lstUno.Items[i].SubItems.Add("(" + iId.ToString () + "," + i.ToString() + ")");
					}
					break;
					//Llaves
				case 7:
					for ( i=0; i<lexema.sLlaves.Length; i++)
					{
						lstUno.Items[i].SubItems.Add("(" + iId.ToString () + "," + i.ToString() + ")");
					}
					break;
					//Identificadores
				case 8:
					for ( i=0; i<CCompoLex.iIdentificador.Count; i++ )
					{
						lstUno.Items[i].SubItems.Add("(" + iId.ToString () + "," + i.ToString() + ")");
					}
					break;

				//Numeros Enteros
				case 9:					
					for ( i=0; i<CCompoLex.NumerosEnteros.Count; i++ )
					{
						lstUno.Items[i].SubItems.Add("(" + iId.ToString () + "," + CCompoLex.NumerosEnteros[i].ToString() + ")");
					}
					break;
				//Numeros Reales
				case 10:
					for ( i=0; i<CCompoLex.NumerosFlotantes.Count; i++ )
					{
						lstUno.Items[i].SubItems.Add("(" + iId.ToString () + "," + CCompoLex.NumerosFlotantes[i].ToString() + ")");
					}
					break;
				//Numeros Notacion Cientifica
				case 11:
					for ( i=0; i<CCompoLex.NumerosNotacionCientifica.Count; i++ )
					{
						lstUno.Items[i].SubItems.Add("(" + iId.ToString () + "," + CCompoLex.NumerosNotacionCientifica[i].ToString() + ")");
					}
					break;
					//Operador de Asignacion
				case 12:					
					lstUno.Items[0].SubItems.Add("(12" + "," + "1)");
					break;
				default:
					break;
			}
		}

		private void loadSimbols ( System.Windows.Forms.ListBox  parLstBx, System.Windows.Forms.ListView parLstVw, string parsTexto )
		{
			System.Windows.Forms.ListBox lstbxTablas = parLstBx;
			System.Windows.Forms.ListView lstUno     = parLstVw;
			string sTexto = parsTexto;
			int iPos = 0;
											
			switch ( sTexto )
			{
				case "Palabras Reservadas":
					loadPalabrasReservadas(lstUno);
					iPos = 1;
					loadTokens ( lstUno, iPos );
					break;	
				
				case "Operadores Aritmeticos":
					iPos = 2;
					loadOperadoresAritmeticos ( lstUno );					
					loadTokens ( lstUno, iPos );
					break;	

				case "Operadores Relacionales":
					iPos = 3;
					loadOperadoresRelacionales ( lstUno );
					loadTokens ( lstUno, iPos );
					break;

				case "Operadores Logicos":	
					iPos = 4;
					loadOperadoresLogicos ( lstUno );
					loadTokens ( lstUno, iPos );
					break;	

				case "Parentesis Circular":
					iPos = 5;
					loadParentesisCircular ( lstUno );
					loadTokens ( lstUno, iPos );
					break;
				
				case "Parentesis Cuadrado":
					iPos = 6;
					loadParentesisCuadrado ( lstUno );
					loadTokens ( lstUno, iPos );
					break;

				case "Llaves":
					iPos = 7;
					loadLlaves ( lstUno );
					loadTokens ( lstUno, iPos );
					break;

				case "Identificadores":
					iPos = 8;
					loadIdentificadores ( lstUno );
					loadTokens ( lstUno, iPos );
					break;		
		
				case "Numeros Enteros":
					iPos = 9;
					loadNumerosEnteros ( lstUno );
					loadTokens ( lstUno, iPos );
					break;	
			
				case "Numeros Reales":
					iPos = 10;
					loadNumerosReales ( lstUno );
					loadTokens ( lstUno, iPos );
					break;	
			
				case "Numeros Notacion Cientifica":
					iPos = 11;
					loadNumerosNotacionCientifica ( lstUno );
					loadTokens ( lstUno, iPos );
					break;																																						
				case "Operador de Asignacion":
					iPos = 12;
					loadOperadorAsignacion ( lstUno );
					loadTokens ( lstUno, iPos );
					break;	
				default:			
					break;
			}
		}										
		

		#endregion

		#region Eventos de los controles

		private void Form2_Load(object sender, System.EventArgs e)
		{
			lexema = new CCompoLex ();
		}
									
		private void lstbxTablas_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string sTexto = string.Empty;
			int iNumTabla = 0;
			iNumTabla = lstbxTablas.SelectedIndex;
			
			sTexto = lstbxTablas.Items[ iNumTabla ].ToString ();
			loadSimbols( lstbxTablas, lstUno, sTexto );
		}	


		#endregion
	}
}

