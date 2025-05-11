using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dll.DL;
namespace dll.BL
{
    public class Hostelbuildings
    {

        private int buildingID;
        private string buildingName;
        private int floors;
        private int rooms;
        private int WardenID;
        private int ServantID;
        private string status;


        public Hostelbuildings()
        {

        }


        public Hostelbuildings(int buildingID, string buildingName, int floors, int rooms, string status,int WardenID)//For update
        {
            this.buildingID = buildingID;
            this.buildingName = buildingName;
            this.floors = floors;
            this.rooms = rooms;
            this.status = status;
            this.WardenID = WardenID;   
        }
        public Hostelbuildings( string buildingName, int floors, int rooms, int wardenID,string status)//For Add
        {
            
            this.buildingName = buildingName;
            this.floors = floors;
            this.rooms = rooms;
            WardenID = wardenID;
            this.status = status;

        }

        public void setbuildingID(int buildingID)
        {
            this.buildingID = buildingID;
        }
        public void setbuildingName(string buildingName)
        {
            this.buildingName = buildingName;
        }
        public void setRooms(int rooms)
        {
            this.rooms = rooms;
        }

        public void setWardenID(int WardenID)
        {
            this.WardenID = WardenID;
        }
        public void setServantID(int servantID)
        {
            this.ServantID = servantID;
        }
        public void setfloors(int floors)
        {
            this.floors = floors;
        }

        public int getRooms()
        {
            return rooms;
        }
        public int getfloors()
        {
            return floors;
        }

        public string getBuildingName()
        {
            return buildingName;
        }

        public int getBuildingID() { 
            return buildingID;
        }
        public int getWardenID()
        {
            return WardenID;
        }
        public int getServantID()
        {
            return ServantID;
        }

        public string Getstatus()
        {
            return status;
        }

        public object GetBuildingID(string buildingNameBefore)
        {
            HostelBuildings h = new HostelBuildings();
            return h.GetIDBuilding(buildingNameBefore);
        }

        

        public bool AddHostelBuilding(Hostelbuildings h)
        {

            HostelBuildings hostelbuildings = new HostelBuildings();
            if(hostelbuildings.Addbuildings(h.getBuildingName(),h.getRooms(),h.getfloors(),h.Getstatus(), h.getWardenID()))
            { return true; }
            return false;

        }



        public bool DeleteBuildings(int buildingid)
        {
            HostelBuildings h = new HostelBuildings();
            return h.DelHostel(buildingid);
        }
        public void DeleteBuildings(Hostelbuildings h)
        {
            DL.HostelBuildings.Deletebuildings(h.getBuildingID());
        }
        public bool UpdateBuildings(Hostelbuildings h)
        {
            HostelBuildings hostelBuildings = new HostelBuildings();
            return hostelBuildings.UpdateBuilding(h.getBuildingID(), h.getBuildingName(), h.getRooms(), h.getfloors(), h.Getstatus(),h.getWardenID());
        }

        public DataTable GetHostelbuildingData()
        {
            HostelBuildings hostelBuildings = new HostelBuildings();
            return hostelBuildings.GetHosteBuildingTable();
        }

        public object getTotalBuildins()
        {
            HostelBuildings hostelBuildings = new HostelBuildings();
            return hostelBuildings.getBuildingsCount();
        }

        public List<object> GetBuildingName()
        {
            DL.HostelBuildings w = new DL.HostelBuildings();
            return w.GetBuildingNamesFromDB();
        }
    }
}
