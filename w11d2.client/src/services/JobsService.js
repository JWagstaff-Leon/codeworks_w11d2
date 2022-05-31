import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class JobsService
{
    async getContractorJobs(contractorId)
    {
        const res = await api.get("api/contractors/" + contractorId + "/jobs");
        logger.log("[JobsService > getContractorJobs > res]", res.data);
        AppState.selectedCompanies = res.data;
    }

    async getCompanyJobs(companyId)
    {
        const res = await api.get("api/companies/" + companyId + "/jobs");
        logger.log("[JobsService > getCompanyJobs > res]", res.data);
        AppState.selectedCompanies = res.data;
    }
}

export const jobsService = new JobsService();