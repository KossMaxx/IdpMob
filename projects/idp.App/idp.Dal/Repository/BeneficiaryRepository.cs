using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using idp.Dal.Models;
using idp.Dal.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace idp.Dal.Repository
{
    public class BeneficiaryRepository : BaseRepository<Beneficiary>, IBeneficiaryRepository
    {
        public BeneficiaryRepository(ApplicationContext context) : base(context)
        {
        }

        public IEnumerable<Beneficiary> GetAll(string creatorName)
        {
            return _db.Include(b => b.DAgeCategory)
                .Include(b=>b.BeneficiaryHelpForms).ThenInclude(h=>h.Help).Where(b => b.CreatorName == creatorName).AsNoTracking();
        }

        public async Task<IEnumerable<Beneficiary>> GetAllAsync(string creatorName)
        {
            return await Task.Run(() => GetAll(creatorName));
        }

        private IEnumerable<Beneficiary> GetAllForServer(string creatorName)
        {
            return _db.Include(b => b.BeneficiaryLawProblems)
                .Include(b => b.BeneficiaryHelpForms)
                .Include(b => b.BeneficiaryProblems)
                .Include(b => b.BeneficiaryConvoyProblems)
                .Include(b => b.BeneficiaryDocProblems)
                .Include(b => b.BeneficiaryInformationSource)
                .Include(b => b.BeneficiaryLivingConditions)
                .Include(b => b.BeneficiaryNotLawHelps)
                .Include(b => b.BeneficiaryVulnerabilities)
                .Include(b => b.BeneficiaryNeeds).Where(b=>b.CreatorName == creatorName).AsNoTracking();
        }

        public async Task<IEnumerable<Beneficiary>> GetAllForServerAsync(string creatorName)
        {
            return await Task.Run(()=> GetAllForServer(creatorName));
        }

        public override Beneficiary Get(int id)
        {
            //var testData = _db.FromSql($"SELECT * FROM Beneficiaries WHERE Id={id}");
            var data = _db.Find(id);
            if (data != null)
            {
                data.DAgeCategory = _db.Include(b => b.DAgeCategory).Single(b => b.Id == id).DAgeCategory;
                data.Office = _db.Include(b => b.Office).Single(b => b.Id == id).Office;
                data.DVpoOrVictimOfConflict = _db.Include(b => b.DVpoOrVictimOfConflict).Single(b => b.Id == id)
                    .DVpoOrVictimOfConflict;
                data.BeneficiaryLivingConditions = _db.Include(b => b.BeneficiaryLivingConditions).ThenInclude(c=>c.Condition)
                    .Single(b => b.Id == id).BeneficiaryLivingConditions;
                data.DTimeSinceRelocation = _db.Include(b => b.DTimeSinceRelocation).Single(b => b.Id == id)
                    .DTimeSinceRelocation;
                data.PollArea = _db.Include(b => b.PollArea).Single(b => b.Id == id).PollArea;
                data.PollRegion = _db.Include(b => b.PollRegion).Single(b => b.Id == id).PollRegion;
                data.PollLocality = _db.Include(b => b.PollLocality).Single(b => b.Id == id).PollLocality;
                data.PPArea = _db.Include(b => b.PPArea).Single(b => b.Id == id).PPArea;
                data.PPRegion = _db.Include(b => b.PPRegion).Single(b => b.Id == id).PPRegion;
                data.PPLocality = _db.Include(b => b.PPLocality).Single(b => b.Id == id).PPLocality;
                data.PIArea = _db.Include(b => b.PIArea).Single(b => b.Id == id).PIArea;
                data.PIRegion = _db.Include(b => b.PIRegion).Single(b => b.Id == id).PIRegion;
                data.PILocality = _db.Include(b => b.PILocality).Single(b => b.Id == id).PILocality;
                data.DNationality = _db.Include(b => b.DNationality).Single(b => b.Id == id).DNationality;
                data.DLivingPlace = _db.Include(b => b.DLivingPlace).Single(b => b.Id == id).DLivingPlace;
                data.DVpoAgent = _db.Include(b => b.DVpoAgent).Single(b => b.Id == id).DVpoAgent;
                data.SocialStatus = _db.Include(b => b.SocialStatus).Single(b => b.Id == id).SocialStatus;
                data.HomeType = _db.Include(b => b.HomeType).Single(b => b.Id == id).HomeType;
                data.DInvalidForm = _db.Include(b => b.DInvalidForm).Single(b => b.Id == id).DInvalidForm;
                data.ActivityForm = _db.Include(b => b.ActivityForm).Single(b => b.Id == id).ActivityForm;
                data.MeetingType = _db.Include(b => b.MeetingType).Single(b => b.Id == id).MeetingType;
                data.DExternalInstitutionType = _db.Include(b => b.DExternalInstitutionType).Single(b => b.Id == id)
                    .DExternalInstitutionType;
                data.BeneficiaryLawProblems = _db.Include(b => b.BeneficiaryLawProblems).ThenInclude(p=>p.LawProblem).Single(b => b.Id == id)
                    .BeneficiaryLawProblems;
                data.BeneficiaryDocProblems = _db.Include(b => b.BeneficiaryDocProblems).ThenInclude(p=>p.DocProblem).Single(b => b.Id == id)
                    .BeneficiaryDocProblems;
                data.BeneficiaryConvoyProblems = _db.Include(b => b.BeneficiaryConvoyProblems).ThenInclude(c=>c.ConvoyProblem).Single(b => b.Id == id)
                    .BeneficiaryConvoyProblems;
                data.BeneficiaryProblems =
                    _db.Include(b => b.BeneficiaryProblems).ThenInclude(p=>p.Problem).Single(b => b.Id == id).BeneficiaryProblems;
                data.BeneficiaryInformationSource = _db.Include(b => b.BeneficiaryInformationSource).ThenInclude(i=>i.InfomationSource)
                    .Single(b => b.Id == id).BeneficiaryInformationSource;
                data.BeneficiaryNotLawHelps = _db.Include(b => b.BeneficiaryNotLawHelps).ThenInclude(h=>h.NotLawHelp).Single(b => b.Id == id)
                    .BeneficiaryNotLawHelps;
                data.BeneficiaryHelpForms = _db.Include(b => b.BeneficiaryHelpForms).ThenInclude(h=>h.Help).Single(b => b.Id == id)
                    .BeneficiaryHelpForms;
                data.BeneficiaryVulnerabilities = _db.Include(b => b.BeneficiaryVulnerabilities).ThenInclude(v=>v.Vulnerability).Single(b => b.Id == id)
                    .BeneficiaryVulnerabilities;
                data.BeneficiaryNeeds = _db.Include(b => b.BeneficiaryNeeds).ThenInclude(n=>n.Need).Single(b => b.Id == id).BeneficiaryNeeds;
            }

            return data;
        }

        public override void Update(Beneficiary newBen)
        {
            var benDb =_db.Find(newBen.Id);

            if (benDb != null)
            {
                benDb.ConvertForUpdate(newBen);

                _context.Entry(benDb).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void AddSyncError(int id, string message)
        {
            var benDb = _db.Find(id);

            if (benDb != null)
            {
                benDb.SyncError = $"{DateTime.Today:dd.MM.yy}-{message}";

                _context.Entry(benDb).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
