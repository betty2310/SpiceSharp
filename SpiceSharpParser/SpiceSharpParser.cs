/* Generated By:CSharpCC: Do not edit this line. SpiceSharpParser.cs */
namespace SpiceSharp.Parser {

using System;
using System.Collections.Generic;
using SpiceSharp;
using SpiceSharp.Parser.Readers;
public class SpiceSharpParser : SpiceSharpParserConstants {

  public void ParseNetlist(Netlist netlist) {
    while (true) {
      switch ((mcc_ntk==-1)?mcc_mntk():mcc_ntk) {
      case DOT:
      case NEWLINE:
      case WORD:
        ;
        break;
      default:
        mcc_la1[0] = mcc_gen;
        goto label_1;
      }
      ParseSpiceLine(netlist);
    }label_1: ;
    
  }

  public void ParseSpiceLine(Netlist netlist) {
        Token t;
        List<Object> parameters = new List<Object>();
        Object o = null;
        Reader reader = null;
    switch ((mcc_ntk==-1)?mcc_mntk():mcc_ntk) {
    case WORD:
      t = mcc_consume_token(WORD);
      while (true) {
        switch ((mcc_ntk==-1)?mcc_mntk():mcc_ntk) {
        case VALUE:
        case STRING:
        case WORD:
        case IDENTIFIER:
          ;
          break;
        default:
          mcc_la1[1] = mcc_gen;
          goto label_2;
        }
        o = ParseParameter();
                                            parameters.Add(o);
      }label_2: ;
      
      switch ((mcc_ntk==-1)?mcc_mntk():mcc_ntk) {
      case NEWLINE:
        mcc_consume_token(NEWLINE);
        break;
      case 0:
        mcc_consume_token(0);
        break;
      default:
        mcc_la1[2] = mcc_gen;
        mcc_consume_token(-1);
        throw new ParseException();
      }
      while (true) {
        switch ((mcc_ntk==-1)?mcc_mntk():mcc_ntk) {
        case PLUS:
          ;
          break;
        default:
          mcc_la1[3] = mcc_gen;
          goto label_3;
        }
        mcc_consume_token(PLUS);
        while (true) {
          switch ((mcc_ntk==-1)?mcc_mntk():mcc_ntk) {
          case VALUE:
          case STRING:
          case WORD:
          case IDENTIFIER:
            ;
            break;
          default:
            mcc_la1[4] = mcc_gen;
            goto label_4;
          }
          o = ParseParameter();
                                                parameters.Add(o);
        }label_4: ;
        
        switch ((mcc_ntk==-1)?mcc_mntk():mcc_ntk) {
        case NEWLINE:
          mcc_consume_token(NEWLINE);
          break;
        case 0:
          mcc_consume_token(0);
          break;
        default:
          mcc_la1[5] = mcc_gen;
          mcc_consume_token(-1);
          throw new ParseException();
        }
      }label_3: ;
      
                // Find a reader that reads this line
                if ((netlist.Parse & Netlist.ParseTypes.Component) != 0)
                {
                        bool found = false;
                        foreach(Reader r in netlist.ComponentReaders)
                        {
                                if (r.Read(t, parameters, netlist))
                                        found = true;
                        }
                        if (!found)
                                {throw new ParseException("Error at line " + t.beginLine + ": Unrecognized component " + t.image);}
                }
      break;
    case DOT:
      mcc_consume_token(DOT);
      t = mcc_consume_token(WORD);
      while (true) {
        switch ((mcc_ntk==-1)?mcc_mntk():mcc_ntk) {
        case VALUE:
        case STRING:
        case WORD:
        case IDENTIFIER:
          ;
          break;
        default:
          mcc_la1[6] = mcc_gen;
          goto label_5;
        }
        o = ParseParameter();
                                                   parameters.Add(o);
      }label_5: ;
      
      switch ((mcc_ntk==-1)?mcc_mntk():mcc_ntk) {
      case NEWLINE:
        mcc_consume_token(NEWLINE);
        break;
      case 0:
        mcc_consume_token(0);
        break;
      default:
        mcc_la1[7] = mcc_gen;
        mcc_consume_token(-1);
        throw new ParseException();
      }
      while (true) {
        switch ((mcc_ntk==-1)?mcc_mntk():mcc_ntk) {
        case PLUS:
          ;
          break;
        default:
          mcc_la1[8] = mcc_gen;
          goto label_6;
        }
        mcc_consume_token(PLUS);
        while (true) {
          switch ((mcc_ntk==-1)?mcc_mntk():mcc_ntk) {
          case VALUE:
          case STRING:
          case WORD:
          case IDENTIFIER:
            ;
            break;
          default:
            mcc_la1[9] = mcc_gen;
            goto label_7;
          }
          o = ParseParameter();
                                                parameters.Add(o);
        }label_7: ;
        
        switch ((mcc_ntk==-1)?mcc_mntk():mcc_ntk) {
        case NEWLINE:
          mcc_consume_token(NEWLINE);
          break;
        case 0:
          mcc_consume_token(0);
          break;
        default:
          mcc_la1[10] = mcc_gen;
          mcc_consume_token(-1);
          throw new ParseException();
        }
      }label_6: ;
      
                // Find a control statement reader
                if ((netlist.Parse & Netlist.ParseTypes.Control) != 0)
                {
                        bool found = false;
                        foreach(Reader r in netlist.ControlReaders)
                        {
                                if (r.Read(t, parameters, netlist))
                                        found = true;
                        }
                        if (!found)
                                {throw new ParseException("Error at line " + t.beginLine + ": Unrecognized control statement " + t.image);}
                }
      break;
    case NEWLINE:
      mcc_consume_token(NEWLINE);
      break;
    default:
      mcc_la1[11] = mcc_gen;
      mcc_consume_token(-1);
      throw new ParseException();
    }
  }

  public Object ParseParameter() {
        Object oa = null, ob = null;
        BracketToken br = null;
    if (mcc_2_1(2)) {
      oa = ParseSingle();
                                          br = new BracketToken(oa);
      mcc_consume_token(1);
      while (true) {
        switch ((mcc_ntk==-1)?mcc_mntk():mcc_ntk) {
        case VALUE:
        case STRING:
        case WORD:
        case IDENTIFIER:
          ;
          break;
        default:
          mcc_la1[12] = mcc_gen;
          goto label_8;
        }
        oa = ParseSingle();
                                                                                                 br.Parameters.Add(oa);
      }label_8: ;
      
      mcc_consume_token(2);
      switch ((mcc_ntk==-1)?mcc_mntk():mcc_ntk) {
      case 3:
        mcc_consume_token(3);
        ob = ParseSingle();
        break;
      default:
        mcc_la1[13] = mcc_gen;
        ;
        break;
      }
                if (ob != null)
                        {return new AssignmentToken(br, ob);}
                {return br;}
    } else if (mcc_2_2(2)) {
      oa = ParseSingle();
      mcc_consume_token(3);
      ob = ParseSingle();
                {return new AssignmentToken(oa, ob);}
    } else {
      switch ((mcc_ntk==-1)?mcc_mntk():mcc_ntk) {
      case VALUE:
      case STRING:
      case WORD:
      case IDENTIFIER:
        oa = ParseSingle();
                {return oa;}
        break;
      default:
        mcc_la1[14] = mcc_gen;
        mcc_consume_token(-1);
        throw new ParseException();
      }
    }
    throw new Exception("Missing return statement in function");
  }

  public Object ParseSingle() {
        Token t;
        List<Token> ts = new List<Token>();
    switch ((mcc_ntk==-1)?mcc_mntk():mcc_ntk) {
    case WORD:
      t = mcc_consume_token(WORD);
      break;
    case VALUE:
      t = mcc_consume_token(VALUE);
      break;
    case STRING:
      t = mcc_consume_token(STRING);
      break;
    case IDENTIFIER:
      t = mcc_consume_token(IDENTIFIER);
      break;
    default:
      mcc_la1[15] = mcc_gen;
      mcc_consume_token(-1);
      throw new ParseException();
    }
                  ts.Add(t);
    while (true) {
      switch ((mcc_ntk==-1)?mcc_mntk():mcc_ntk) {
      case COMMA:
        ;
        break;
      default:
        mcc_la1[16] = mcc_gen;
        goto label_9;
      }
      mcc_consume_token(COMMA);
      switch ((mcc_ntk==-1)?mcc_mntk():mcc_ntk) {
      case WORD:
        t = mcc_consume_token(WORD);
        break;
      case VALUE:
        t = mcc_consume_token(VALUE);
        break;
      case STRING:
        t = mcc_consume_token(STRING);
        break;
      case IDENTIFIER:
        t = mcc_consume_token(IDENTIFIER);
        break;
      default:
        mcc_la1[17] = mcc_gen;
        mcc_consume_token(-1);
        throw new ParseException();
      }
                  ts.Add(t);
    }label_9: ;
    
                if (ts.Count > 1)
                        {return (Token[])(ts.ToArray());}
                else
                        {return ts[0];}
    throw new Exception("Missing return statement in function");
  }

  private bool mcc_2_1(int xla) {
    mcc_la = xla; mcc_lastpos = mcc_scanpos = token;
    try { return !mcc_3_1(); }
    catch(LookaheadSuccess) { return true; }
    finally { mcc_save(0, xla); }
  }

  private bool mcc_2_2(int xla) {
    mcc_la = xla; mcc_lastpos = mcc_scanpos = token;
    try { return !mcc_3_2(); }
    catch(LookaheadSuccess) { return true; }
    finally { mcc_save(1, xla); }
  }

  private bool mcc_3R_11() {
    if (mcc_scan_token(COMMA)) return true;
    return false;
  }

  private bool mcc_3R_10() {
    Token xsp;
    xsp = mcc_scanpos;
    if (mcc_scan_token(15)) {
    mcc_scanpos = xsp;
    if (mcc_scan_token(13)) {
    mcc_scanpos = xsp;
    if (mcc_scan_token(14)) {
    mcc_scanpos = xsp;
    if (mcc_scan_token(16)) return true;
    }
    }
    }
    while (true) {
      xsp = mcc_scanpos;
      if (mcc_3R_11()) { mcc_scanpos = xsp; break; }
    }
    return false;
  }

  private bool mcc_3_1() {
    if (mcc_3R_10()) return true;
    if (mcc_scan_token(1)) return true;
    return false;
  }

  private bool mcc_3_2() {
    if (mcc_3R_10()) return true;
    if (mcc_scan_token(3)) return true;
    return false;
  }

  public SpiceSharpParserTokenManager token_source;
  SimpleCharStream mcc_input_stream;
  public Token token, mcc_nt;
  private int mcc_ntk;
  private Token mcc_scanpos, mcc_lastpos;
  private int mcc_la;
  public bool lookingAhead = false;
  private bool mcc_semLA;
  private int mcc_gen;
  private int[] mcc_la1 = new int[18];
  static private int[] mcc_la1_0;
  static SpiceSharpParser() {
      mcc_gla1_0();
   }
   private static void mcc_gla1_0() {
      mcc_la1_0 = new int[] {37376,122880,4097,128,122880,4097,122880,4097,128,122880,4097,37376,122880,8,122880,122880,1024,122880,};
   }
  private MccCalls[] mcc_2_rtns = new MccCalls[2];
  private bool mcc_rescan = false;
  private int mcc_gc = 0;

  public SpiceSharpParser(System.IO.Stream stream) {
    mcc_input_stream = new SimpleCharStream(stream, 1, 1);
    token_source = new SpiceSharpParserTokenManager(mcc_input_stream);
    token = new Token();
    mcc_ntk = -1;
    mcc_gen = 0;
    for (int i = 0; i < 18; i++) mcc_la1[i] = -1;
    for (int i = 0; i < mcc_2_rtns.Length; i++) mcc_2_rtns[i] = new MccCalls();
  }

  public void ReInit(System.IO.Stream stream) {
    mcc_input_stream.ReInit(stream, 1, 1);
    token_source.ReInit(mcc_input_stream);
    token = new Token();
    mcc_ntk = -1;
    mcc_gen = 0;
    for (int i = 0; i < 18; i++) mcc_la1[i] = -1;
    for (int i = 0; i < mcc_2_rtns.Length; i++) mcc_2_rtns[i] = new MccCalls();
  }

  public SpiceSharpParser(System.IO.TextReader stream) {
    mcc_input_stream = new SimpleCharStream(stream, 1, 1);
    token_source = new SpiceSharpParserTokenManager(mcc_input_stream);
    token = new Token();
    mcc_ntk = -1;
    mcc_gen = 0;
    for (int i = 0; i < 18; i++) mcc_la1[i] = -1;
    for (int i = 0; i < mcc_2_rtns.Length; i++) mcc_2_rtns[i] = new MccCalls();
  }

  public void ReInit(System.IO.TextReader stream) {
    mcc_input_stream.ReInit(stream, 1, 1);
    token_source.ReInit(mcc_input_stream);
    token = new Token();
    mcc_ntk = -1;
    mcc_gen = 0;
    for (int i = 0; i < 18; i++) mcc_la1[i] = -1;
    for (int i = 0; i < mcc_2_rtns.Length; i++) mcc_2_rtns[i] = new MccCalls();
  }

  public SpiceSharpParser(SpiceSharpParserTokenManager tm) {
    token_source = tm;
    token = new Token();
    mcc_ntk = -1;
    mcc_gen = 0;
    for (int i = 0; i < 18; i++) mcc_la1[i] = -1;
    for (int i = 0; i < mcc_2_rtns.Length; i++) mcc_2_rtns[i] = new MccCalls();
  }

  public void ReInit(SpiceSharpParserTokenManager tm) {
    token_source = tm;
    token = new Token();
    mcc_ntk = -1;
    mcc_gen = 0;
    for (int i = 0; i < 18; i++) mcc_la1[i] = -1;
    for (int i = 0; i < mcc_2_rtns.Length; i++) mcc_2_rtns[i] = new MccCalls();
  }

   private Token mcc_consume_token(int kind) {
    Token oldToken = null;
    if ((oldToken = token).next != null) token = token.next;
    else token = token.next = token_source.GetNextToken();
    mcc_ntk = -1;
    if (token.kind == kind) {
      mcc_gen++;
      if (++mcc_gc > 100) {
        mcc_gc = 0;
        for (int i = 0; i < mcc_2_rtns.Length; i++) {
          MccCalls c = mcc_2_rtns[i];
          while (c != null) {
            if (c.gen < mcc_gen) c.first = null;
            c = c.next;
          }
        }
      }
      return token;
    }
    token = oldToken;
    mcc_kind = kind;
    throw GenerateParseException();
  }

  private class LookaheadSuccess : System.Exception { }
  private LookaheadSuccess mcc_ls = new LookaheadSuccess();
  private bool mcc_scan_token(int kind) {
    if (mcc_scanpos == mcc_lastpos) {
      mcc_la--;
      if (mcc_scanpos.next == null) {
        mcc_lastpos = mcc_scanpos = mcc_scanpos.next = token_source.GetNextToken();
      } else {
        mcc_lastpos = mcc_scanpos = mcc_scanpos.next;
      }
    } else {
      mcc_scanpos = mcc_scanpos.next;
    }
    if (mcc_rescan) {
      int i = 0; Token tok = token;
      while (tok != null && tok != mcc_scanpos) { i++; tok = tok.next; }
      if (tok != null) mcc_add_error_token(kind, i);
    }
    if (mcc_scanpos.kind != kind) return true;
    if (mcc_la == 0 && mcc_scanpos == mcc_lastpos) throw mcc_ls;
    return false;
  }

  public Token GetNextToken() {
    if (token.next != null) token = token.next;
    else token = token.next = token_source.GetNextToken();
    mcc_ntk = -1;
    mcc_gen++;
    return token;
  }

  public Token GetToken(int index) {
    Token t = lookingAhead ? mcc_scanpos : token;
    for (int i = 0; i < index; i++) {
      if (t.next != null) t = t.next;
      else t = t.next = token_source.GetNextToken();
    }
    return t;
  }

  private int mcc_mntk() {
    if ((mcc_nt=token.next) == null)
      return (mcc_ntk = (token.next=token_source.GetNextToken()).kind);
    else
      return (mcc_ntk = mcc_nt.kind);
  }

  private System.Collections.ArrayList mcc_expentries = new System.Collections.ArrayList();
  private int[] mcc_expentry;
  private int mcc_kind = -1;
  private int[] mcc_lasttokens = new int[100];
  private int mcc_endpos;

  private void mcc_add_error_token(int kind, int pos) {
    if (pos >= 100) return;
    if (pos == mcc_endpos + 1) {
      mcc_lasttokens[mcc_endpos++] = kind;
    } else if (mcc_endpos != 0) {
      mcc_expentry = new int[mcc_endpos];
      for (int i = 0; i < mcc_endpos; i++) {
        mcc_expentry[i] = mcc_lasttokens[i];
      }
      bool exists = false;
      for (System.Collections.IEnumerator e = mcc_expentries.GetEnumerator(); e.MoveNext();) {
        int[] oldentry = (int[])e.Current;
        if (oldentry.Length == mcc_expentry.Length) {
          exists = true;
          for (int i = 0; i < mcc_expentry.Length; i++) {
            if (oldentry[i] != mcc_expentry[i]) {
              exists = false;
              break;
            }
          }
          if (exists) break;
        }
      }
      if (!exists) mcc_expentries.Add(mcc_expentry);
      if (pos != 0) mcc_lasttokens[(mcc_endpos = pos) - 1] = kind;
    }
  }

  public ParseException GenerateParseException() {
    mcc_expentries.Clear();
    bool[] la1tokens = new bool[20];
    for (int i = 0; i < 20; i++) {
      la1tokens[i] = false;
    }
    if (mcc_kind >= 0) {
      la1tokens[mcc_kind] = true;
      mcc_kind = -1;
    }
    for (int i = 0; i < 18; i++) {
      if (mcc_la1[i] == mcc_gen) {
        for (int j = 0; j < 32; j++) {
          if ((mcc_la1_0[i] & (1<<j)) != 0) {
            la1tokens[j] = true;
          }
        }
      }
    }
    for (int i = 0; i < 20; i++) {
      if (la1tokens[i]) {
        mcc_expentry = new int[1];
        mcc_expentry[0] = i;
        mcc_expentries.Add(mcc_expentry);
      }
    }
    mcc_endpos = 0;
    mcc_rescan_token();
    mcc_add_error_token(0, 0);
    int[][] exptokseq = new int[mcc_expentries.Count][];
    for (int i = 0; i < mcc_expentries.Count; i++) {
      exptokseq[i] = (int[])mcc_expentries[i];
    }
    return new ParseException(token, exptokseq, tokenImage);
  }

  public void enable_tracing() {
  }

  public void disable_tracing() {
  }

  private void mcc_rescan_token() {
    mcc_rescan = true;
    for (int i = 0; i < 2; i++) {
      MccCalls p = mcc_2_rtns[i];
      do {
        if (p.gen > mcc_gen) {
          mcc_la = p.arg; mcc_lastpos = mcc_scanpos = p.first;
          switch (i) {
            case 0: mcc_3_1(); break;
            case 1: mcc_3_2(); break;
          }
        }
        p = p.next;
      } while (p != null);
    }
    mcc_rescan = false;
  }

  private void mcc_save(int index, int xla) {
    MccCalls p = mcc_2_rtns[index];
    while (p.gen > mcc_gen) {
      if (p.next == null) { p = p.next = new MccCalls(); break; }
      p = p.next;
    }
    p.gen = mcc_gen + xla - mcc_la; p.first = token; p.arg = xla;
  }

  class MccCalls {
    public int gen;
    public Token first;
    public int arg;
    public MccCalls next;
  }

}
}
