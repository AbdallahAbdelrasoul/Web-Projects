package mypackage;

import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

//import com.sun.javafx.collections.MappingChange.Map;

/**
 * Servlet implementation class Servlet_Loading
 */
@WebServlet("/Servlet_Loading")
public class Servlet_Loading extends HttpServlet {
	private static final long serialVersionUID = 1L;

	LoadData ld = null;

	ArrayList<String> ET = new ArrayList<String>();
	HashMap<String, String> Qes = new HashMap<>();
	HashMap<String, String> Ans = new HashMap<>();

	HttpSession session = null;

	/**
	 * @see HttpServlet#HttpServlet()
	 */
	public Servlet_Loading() {
		// TODO Auto-generated constructor stub
		super();
		ld = new LoadData();
		ET = null;
		Qes = null;
		Ans = null;
	}

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse
	 *      response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		// TODO Auto-generated method stub
		String OP = request.getParameter("OP").toString(); // Operation
		session = request.getSession(); // the same thing like request.getSession(true);
		if (OP.equals("sh_ex")) { // on click of "List of Exams" Button:

			String cid = session.getAttribute("CID").toString();
			System.out.println("CID: " + cid);
			ET = ld.Exam_of_cand(cid);
			session.setAttribute("Exams", ET);
			response.sendRedirect("ShowExmas.jsp");

		} else if (OP.equals("sh_Q")) {// on click of "Exam" Button:
			// three random Questions for Exam.......................................
			String myExam = request.getParameter("ET");
			Qes = ld.Random_Ques_of_exam(myExam);
			System.out.println("Qes HashMap:" + Qes);
			session.setAttribute("Qes", Qes);
			System.out.println("Exam: " + myExam);
			System.out.println("........................................");
			// .......................................................................
			// answers for questions
			System.out.println("Qes_size:" + Qes.size());

			int i = 0;
			for (String key : Qes.keySet()) {
				if (i == 0)
					Ans = ld.Ans_of_Qes(key);
				else
					Ans.putAll(ld.Ans_of_Qes(key));
				i++;
			}
			session.setAttribute("Ans", Ans);

			System.out.println("Ans_size:" + Ans.size());

			response.sendRedirect("MyExam.jsp?ET=" + myExam);
		}

	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse
	 *      response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		// TODO Auto-generated method stub
		doGet(request, response);
	}

}
