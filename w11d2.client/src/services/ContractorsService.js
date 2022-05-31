import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class ContractorsService   
{
    async getAll()
    {
        const res = await api.get("api/contractors");
        logger.log("[ContractorsService > getAll > res]", res.data);
        AppState.contractors = res.data;
    }

    async create(data)
    {
        const res = await api.post("api/contractors", data);
        logger.log("[ContractorsService > create > res]", res.data);
        AppState.contractors.push(res.data);
    }
}

export const contractorsService = new ContractorsService();