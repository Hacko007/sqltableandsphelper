﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ColumnDepence.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ColumnDepence.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        public static System.Drawing.Bitmap _1322752321_grid {
            get {
                object obj = ResourceManager.GetObject("_1322752321_grid", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        public static System.Drawing.Bitmap CloseImage {
            get {
                object obj = ResourceManager.GetObject("CloseImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to  DB Info .
        /// </summary>
        public static string ColumnDependencies_SetTitle__DB_Info_ {
            get {
                return ResourceManager.GetString("ColumnDependencies_SetTitle__DB_Info_", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to  DB Info  -   .
        /// </summary>
        public static string ColumnDependencies_SetTitle__DB_Info______ {
            get {
                return ResourceManager.GetString("ColumnDependencies_SetTitle__DB_Info______", resourceCulture);
            }
        }
        
        public static System.Drawing.Bitmap Connect {
            get {
                object obj = ResourceManager.GetObject("Connect", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        public static System.Drawing.Bitmap filter_data_by_criteria {
            get {
                object obj = ResourceManager.GetObject("filter_data_by_criteria", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        public static System.Drawing.Bitmap FilterByWholeRow {
            get {
                object obj = ResourceManager.GetObject("FilterByWholeRow", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        public static System.Drawing.Icon ForegnKeyIcon {
            get {
                object obj = ResourceManager.GetObject("ForegnKeyIcon", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT  COLUMN_NAME As Name , 
        ///DATA_TYPE As [Type], 
        ///CASE IS_NULLABLE  WHEN &apos;NO&apos; THEN cast(0 as Bit)  ELSE cast (1 as BIT) END as Nullable,
        ///CHARACTER_MAXIMUM_LENGTH As [Max] , 
        ///COLUMN_DEFAULT AS [Default] 
        ///FROM   INFORMATION_SCHEMA.COLUMNS 
        ///WHERE  (TABLE_NAME = @TABSEARCH) ORDER BY ORDINAL_POSITION.
        /// </summary>
        public static string GetColumnInfoForTable {
            get {
                return ResourceManager.GetString("GetColumnInfoForTable", resourceCulture);
            }
        }
        
        public static System.Drawing.Bitmap LoadAllValues {
            get {
                object obj = ResourceManager.GetObject("LoadAllValues", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        public static System.Drawing.Bitmap LoadDefinitionImage {
            get {
                object obj = ResourceManager.GetObject("LoadDefinitionImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        public static System.Drawing.Bitmap m_ToolStripButtonExecSp_Image {
            get {
                object obj = ResourceManager.GetObject("m_ToolStripButtonExecSp_Image", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        public static System.Drawing.Bitmap Number {
            get {
                object obj = ResourceManager.GetObject("Number", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        public static System.Drawing.Icon PrimaryKeyIcon {
            get {
                object obj = ResourceManager.GetObject("PrimaryKeyIcon", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        public static System.Drawing.Icon programIcon {
            get {
                object obj = ResourceManager.GetObject("programIcon", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        public static System.Drawing.Bitmap Reload {
            get {
                object obj = ResourceManager.GetObject("Reload", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT COL2.name AS Parent_Column , COL1.name AS Referenced_Column , tb.name AS TableName 
        /// FROM sys.columns AS COL1 INNER JOIN
        ///                      sys.columns AS COL2 INNER JOIN
        ///                      sys.tables AS tb2 INNER JOIN
        ///                      sys.foreign_key_columns AS FK INNER JOIN
        ///                      sys.tables AS tb ON FK.parent_object_id = tb.object_id ON tb2.object_id = FK.referenced_object_id ON COL2.column_id = FK.referenced_column_id AND
        ///                       COL2.object_id = FK. [rest of string was truncated]&quot;;.
        /// </summary>
        public static string SqlGetChildTables {
            get {
                return ResourceManager.GetString("SqlGetChildTables", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select CN.COLUMN_NAME As [Column] ,TB.CONSTRAINT_NAME as [Constraint] , TB.CONSTRAINT_TYPE as [Type] 
        /// from  INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE CN inner join 
        ///  INFORMATION_SCHEMA.TABLE_CONSTRAINTS TB on (CN.TABLE_NAME = TB.TABLE_NAME AND CN.CONSTRAINT_NAME = TB.CONSTRAINT_NAME) 
        /// WHERE  CN.TABLE_NAME = @TABSEARCH.
        /// </summary>
        public static string SqlGetColumnConstrains {
            get {
                return ResourceManager.GetString("SqlGetColumnConstrains", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT   sys.columns.name as IdentityColumn
        ///FROM     sys.tables INNER JOIN
        ///         sys.columns ON sys.tables.object_id = sys.columns.object_id
        ///WHERE  (sys.columns.is_identity = 1) AND (sys.tables.name =@TABSEARCH ).
        /// </summary>
        public static string SqlGetIdentityColumns {
            get {
                return ResourceManager.GetString("SqlGetIdentityColumns", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT    COL1.name AS Referenced_Column , COL2.name AS Parent_Column ,tb2.name AS TableName 
        ///FROM  sys.columns AS COL1 INNER JOIN
        ///                      sys.columns AS COL2 INNER JOIN
        ///                      sys.tables AS tb2 INNER JOIN
        ///                      sys.foreign_key_columns AS FK INNER JOIN
        ///                      sys.tables AS tb ON FK.parent_object_id = tb.object_id ON tb2.object_id = FK.referenced_object_id ON COL2.column_id = FK.referenced_column_id AND
        ///                       COL2.object_id =  [rest of string was truncated]&quot;;.
        /// </summary>
        public static string SqlGetParentTables {
            get {
                return ResourceManager.GetString("SqlGetParentTables", resourceCulture);
            }
        }
        
        public static System.Drawing.Bitmap text_align_justify {
            get {
                object obj = ResourceManager.GetObject("text_align_justify", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        public static System.Drawing.Bitmap Time {
            get {
                object obj = ResourceManager.GetObject("Time", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        public static System.Drawing.Bitmap ToolBoxImage {
            get {
                object obj = ResourceManager.GetObject("ToolBoxImage", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to  try.
        /// </summary>
        public static string UserControlSpInfo_FillSpDefinition__try {
            get {
                return ResourceManager.GetString("UserControlSpInfo_FillSpDefinition__try", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Loading SP definition ....
        /// </summary>
        public static string UserControlSpInfo_FillSpDefinition_Loading_SP_definition____ {
            get {
                return ResourceManager.GetString("UserControlSpInfo_FillSpDefinition_Loading_SP_definition____", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Column.
        /// </summary>
        public static string UserControlSpInfo_InitCoulomnsInDvDepTables_Column {
            get {
                return ResourceManager.GetString("UserControlSpInfo_InitCoulomnsInDvDepTables_Column", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Dependent Object.
        /// </summary>
        public static string UserControlSpInfo_InitCoulomnsInDvDepTables_Dependent_Object {
            get {
                return ResourceManager.GetString("UserControlSpInfo_InitCoulomnsInDvDepTables_Dependent_Object", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Selected.
        /// </summary>
        public static string UserControlSpInfo_InitCoulomnsInDvDepTables_Selected {
            get {
                return ResourceManager.GetString("UserControlSpInfo_InitCoulomnsInDvDepTables_Selected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Type.
        /// </summary>
        public static string UserControlSpInfo_InitCoulomnsInDvDepTables_Type {
            get {
                return ResourceManager.GetString("UserControlSpInfo_InitCoulomnsInDvDepTables_Type", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Updated.
        /// </summary>
        public static string UserControlSpInfo_InitCoulomnsInDvDepTables_Updated {
            get {
                return ResourceManager.GetString("UserControlSpInfo_InitCoulomnsInDvDepTables_Updated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Syntax highligting.
        /// </summary>
        public static string UserControlSpInfo_SyntaxHighLight_Syntax_highligting {
            get {
                return ResourceManager.GetString("UserControlSpInfo_SyntaxHighLight_Syntax_highligting", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Show as tab page.
        /// </summary>
        public static string UserControlSpInfo_ToolStripButtonShowAsToolBox_Click_Show_as_tab_page {
            get {
                return ResourceManager.GetString("UserControlSpInfo_ToolStripButtonShowAsToolBox_Click_Show_as_tab_page", resourceCulture);
            }
        }
    }
}
