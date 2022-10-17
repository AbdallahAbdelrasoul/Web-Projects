package mvc.model.Objects;


public class Player {
    private String id;
    private String team_id;
    private String name;
    private String pos;
    private String dof;
    public Player() {
        
    }
    public Player(String id, String team_id, String name, String pos , String DOF) {
        super();
        this.id = id;
        this.team_id = team_id;
        this.name = name;
        this.pos = pos;
        this.dof = DOF;
    }
    public String getId() {
        return id;
    }
    public void setId(String id) {
        this.id = id;
    }
    public String getTeamId() {
        return team_id;
    }
    public void setTeamId(String team_id) {
        this.team_id = team_id;
    }
    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }
    public String getPosition() {
        return pos;
    }
    public void setPosition(String pos) {
        this.pos = pos;
    }
    public String getDOF() {
        return dof;
    }
    public void setDOF(String DOF) {
        this.dof = DOF;
    }
    
}
