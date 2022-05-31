import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class CompaniesService
{
    async getAll()
    {
        const res = await api.get("api/companies");
        logger.log("[CompaniesService > getAll > res]", res.data);
        AppState.companies = res.data;
    }

    async create(data)
    {
        const res = await api.post("api/companies", data);
        logger.log("[CompaniesService > create > res]", res.data);
        AppState.companies.push(res.data);
    }
}

export const companiesService = new CompaniesService();