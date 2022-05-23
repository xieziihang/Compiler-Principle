const TokenType = {
  // 加减乘除运算符
  Add: 'Add', // + 
  Subtract: 'Subtract', // -
  Multiply: 'Multiply', // * 
  Divide: 'Divide', // /

  // 比较运算符
  GT: 'GT', // >
  GE: 'GE', // >=
  LT: 'LT', // <
  LE: 'LE', // <=

  SemiColon: 'SemiColon', // ;
  LeftParen: 'LeftParen', // (
  RightParen: 'RightParen', // )
  Assignment: 'Assignment', // =

  If: 'If', // if
  Else: 'Else', // else

  Int: 'Int', // int

  Indentifier: 'Indentifier', // 标识符

  IntLiteral: 'IntLiteral', // 整型字面量
  StringLiteral: 'StringLiteral' // 字符串字面量
}

export default TokenType; 