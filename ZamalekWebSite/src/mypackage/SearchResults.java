package mypackage;

import java.io.IOException;
import java.util.ArrayList;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

/**
 * Servlet implementation class SearchResults
 */
@WebServlet("/SearchResults")
public class SearchResults extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public SearchResults() {
        super();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		
		HttpSession mysession = request.getSession(true);
		LoadData ld = new LoadData();
		ArrayList<String> matches = new ArrayList<String>();

		String txt = request.getParameter("stxtn");
		System.out.println(txt);
		if (request.getParameter("stxtn") != null && txt != "") {
			matches = ld.selectMatches(txt);
			System.out.println("matches : " + matches);
			mysession.setAttribute("matches", matches);
			response.sendRedirect("SearchResults.jsp");
		}
		else {
			System.out.print("no data");
			response.getWriter().append("no data");
		}
	
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		doGet(request, response);
	}

}
