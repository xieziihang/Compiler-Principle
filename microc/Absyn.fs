(* File MicroC/Absyn.fs
   Abstract syntax of micro-C, an imperative language.
   sestoft@itu.dk 2009-09-25

   Must precede Interp.fs, Comp.fs and Contcomp.fs in Solution Explorer
 *)

module Absyn

// 基本类型
// 注意，数组、指针是递归类型
// 这里没有函数类型，注意与上次课的 MicroML 对比
type typ =
  | TypI                             (* Type int                    *)
  | TypC                             (* Type char                   *)
  | TypB                             (* Type bool                   *)
  | TypA of typ * int option         (* Array type                  *)
  | TypP of typ                      (* Pointer type                *)
                                                                   
and expr =                           // 表达式，右值 
  | SelfInc of access                (* x++                         *)
  | SelfDec of access                (* x--                         *)                                               
  | Access of access                 (* x    or  *p    or  a[e]     *) //访问左值（右值）
  | Assign of access * expr          (* x=e  or  *p=e  or  a[e]=e   *)
  | Addr of access                   (* &x   or  &*p   or  &a[e]    *)
  | CstI of int                      (* Constant                    *)
  | Prim1 of string * expr           (* Unary primitive operator    *)
  | Prim2 of string * expr * expr    (* Binary primitive operator   *)
  | Prim3 of expr * expr *expr       (* 三目运算符                   *)
  | PlusAssign  of access * expr     (* +=                          *)
  | MinusAssign  of access * expr    (* -=                          *)
  | MultiplyAssign  of access * expr (* *=                          *)
  | DivAssign  of access * expr      (* /=                          *)
  | Andalso of expr * expr           (* Sequential and              *)
  | Orelse of expr * expr            (* Sequential or               *)
  | Call of string * expr list       (* Function call f(...)        *)
  | Max of expr * expr               (* 两者取较大                   *)
  | Min of expr * expr               (* 两者取较小                   *) 
  | Abs of expr                      (* 取绝对值                     *)

and access =                         //左值，存储的位置                                            
  | AccVar of string                 (* Variable access        x    *) 
  | AccDeref of expr                 (* Pointer dereferencing  *p   *)
  | AccIndex of access * expr        (* Array indexing         a[e] *)
                                                                  
and stmt =                                                         
  | If of expr * stmt * stmt         (* Conditional                 *)
  | For of expr * expr * expr * stmt (* for 循环                    *)
  | While of expr * stmt             (* While loop                  *)
  | DoWhile of stmt * expr           (* do ... while 循环           *)
  | Expr of expr                     (* Expression statement   e;   *)
  | Return of expr option            (* Return from method          *)
  | Block of stmtordec list          (* Block: grouping and scope   *)
  | Switch of expr * stmt list       (* Switch                      *)
  | Case of expr * stmt              (* Case                        *)
  // 语句块内部，可以是变量声明 或语句的列表                                                              

and stmtordec =                                                    
  | Dec of typ * string              (* Local variable declaration  *)
  | Stmt of stmt                     (* A statement                 *)

// 顶级声明 可以是函数声明或变量声明
and topdec = 
  | Fundec of typ option * string * (typ * string) list * stmt
  | Vardec of typ * string
  
// 程序是顶级声明的列表
and program = 
  | Prog of topdec list
